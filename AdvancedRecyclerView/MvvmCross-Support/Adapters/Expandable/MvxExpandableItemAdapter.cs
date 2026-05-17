using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Android.Runtime;
using AndroidX.RecyclerView.Widget;
using Android.Views;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Utils;
using Microsoft.Extensions.Logging;
using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;
using MvvmCross.AdvancedRecyclerView.Data.ItemUniqueIdProvider;
using MvvmCross.AdvancedRecyclerView.Extensions;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions.ItemManager;
using MvvmCross.AdvancedRecyclerView.Swipe.State;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using MvvmCross.AdvancedRecyclerView.Utils;
using MvvmCross.AdvancedRecyclerView.ViewHolders;
using MvvmCross.Binding.Extensions;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.DroidX.RecyclerView.ItemTemplates;
using MvvmCross.Exceptions;
using MvvmCross.Logging;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Object = Java.Lang.Object;

namespace MvvmCross.AdvancedRecyclerView.Adapters.Expandable
{
    public class MvxExpandableItemAdapter : AbstractExpandableItemAdapter, IExpandableSwipeableItemAdapter, IMvxAdvancedRecyclerViewAdapter
    {
        private readonly Lazy<DefaultSwipeableTemplate> _lazyDefaultSwipeableTemplate = new Lazy<DefaultSwipeableTemplate>();
        private readonly Dictionary<long, SwipeResultAction> _pendingGroupSwipeActions = new Dictionary<long, SwipeResultAction>();
        private readonly Dictionary<long, SwipeResultAction> _pendingChildSwipeActions = new Dictionary<long, SwipeResultAction>();
           
        private readonly MvxGroupedItemsSourceProvider _expandableGroupedItemsSourceProvider;
        private IEnumerable itemsSource;
        private MvxSwipeableTemplate groupedSwipeableTemplate;
        private MvxSwipeableTemplate childSwipeableTemplate;

        public MvxExpandableItemAdapter() : this(MvxAndroidBindingContextHelpers.Current())
        {
        }

        public MvxExpandableItemAdapter(IMvxAndroidBindingContext androidBindingContext)
        {
            BindingContext = androidBindingContext;
            HasStableIds = true;
            _expandableGroupedItemsSourceProvider = new MvxGroupedItemsSourceProvider();
            _expandableGroupedItemsSourceProvider.Source.CollectionChanged += SourceOnCollectionChanged;
            _expandableGroupedItemsSourceProvider.ChildItemsAdded += SourceItemChildChanged;
            _expandableGroupedItemsSourceProvider.ChildItemsRemoved += SourceItemChildChanged;
            _expandableGroupedItemsSourceProvider.ChildItemsCollectionCleared += (group) => base.NotifyDataSetChanged();
            _expandableGroupedItemsSourceProvider.ItemsMovedOrReplaced += () => base.NotifyDataSetChanged();
            GroupSwipeItemPinnedStateController = new SwipeItemPinnedStateControllerProvider()
            {
                UniqueIdProvider = new GroupMvxItemUniqueIdProvider(this)
            };
            ChildSwipeItemPinnedStateController = new SwipeItemPinnedStateControllerProvider()
            {
                UniqueIdProvider = new GroupChildMvxItemUniqueIdProvider(this)
            };
        }

        protected MvxExpandableItemAdapter(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
        
        protected IMvxAndroidBindingContext BindingContext { get; }

        public IMvxTemplateSelector TemplateSelector { get; set; }

        private ObservableCollection<object> GroupedItems => _expandableGroupedItemsSourceProvider.Source;

        public IEnumerable ItemsSource
        {
            get => itemsSource;
            set
            {
                if (ReferenceEquals(itemsSource, value))
                    return;
                itemsSource = value;
                _expandableGroupedItemsSourceProvider.Initialize(itemsSource, ExpandableDataConverter);
                NotifyDataSetChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        public MvxExpandableDataConverter ExpandableDataConverter { get; set; }

        public MvxGroupExpandController GroupExpandController { get; internal set; } = new DefaultMvxGroupExpandController();

        public override int GroupCount => GroupedItems.Count();

        public ICommand GroupItemClickCommand { get; set; }

        public ICommand GroupItemLongClickCommand { get; set; }

        public ICommand ChildItemClickCommand { get; set; }

        public ICommand ChildItemLongClickCommand { get; set; }

        void SourceItemChildChanged(Data.MvxGroupedData gropedData, IEnumerable newItems)
        {
            base.NotifyDataSetChanged();
        }

        private void SourceOnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            NotifyDataSetChanged(notifyCollectionChangedEventArgs);
        }

        public virtual void NotifyDataSetChanged(NotifyCollectionChangedEventArgs e)
        {
            try
            {
                NotifyDataSetChanged();
                return; 
            }
            catch (Exception exception)
            {
                Mvx.IoCProvider.TryResolve(out ILogger logger);
                logger?.Log(LogLevel.Warning, 
                    $"Exception masked during Adapter RealNotifyDataSetChanged {exception.Message}. Are you trying to update your collection from a background task? See http://goo.gl/0nW0L6"
                );
            }
        }

        public override bool OnCheckCanExpandOrCollapseGroup(Object holder, int groupPosition, int x, int y, bool expand)
        {
            var groupItemDetails = new MvxGroupDetails
            {
                Holder = holder as RecyclerView.ViewHolder,
                Item = GroupedItems.ElementAt(groupPosition) as MvxGroupedData,
                GroupIndex = groupPosition
            };

            if (expand)
                return GroupExpandController.CanExpandGroup(groupItemDetails);

            return GroupExpandController.CanCollapseGroup(groupItemDetails);
        }

        public override Object OnCreateChildViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);

            var viewHolder =
                new MvxExpandableRecyclerViewHolder(
                    InflateViewForHolder(TemplateSelector.GetItemLayoutId(viewType), parent, viewType, itemBindingContext),
                    ChildSwipeableTemplate.SwipeContainerViewGroupId,
                    ChildSwipeableTemplate.UnderSwipeContainerViewGroupId,
                    itemBindingContext)
                {
                };

            viewHolder.Click += (e, a) =>
            {
                if (ChildItemClickCommand?.CanExecute(viewHolder.DataContext) ?? false)
                    ChildItemClickCommand.Execute(viewHolder.DataContext);
            };

            viewHolder.LongClick += (e, a) =>
            {
                if (ChildItemLongClickCommand?.CanExecute(viewHolder.DataContext) ?? false)
                    ChildItemLongClickCommand.Execute(viewHolder.DataContext);
            };

            return viewHolder;
        }

        public override Object OnCreateGroupViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);

            var viewHolder =
                new MvxExpandableRecyclerViewHolder(
                    InflateViewForHolder(TemplateSelector.GetItemLayoutId(viewType), parent, viewType, itemBindingContext),
                    GroupSwipeableTemplate.SwipeContainerViewGroupId,
                    GroupSwipeableTemplate.UnderSwipeContainerViewGroupId,
                    itemBindingContext)
                { 
                };

            viewHolder.Click += (e, a) =>
            {
                if (GroupItemClickCommand?.CanExecute(viewHolder.DataContext) ?? false)
                    GroupItemClickCommand.Execute(viewHolder.DataContext);
            };

            viewHolder.LongClick += (e, a) =>
            {
                if (GroupItemLongClickCommand?.CanExecute(viewHolder.DataContext) ?? false)
                    GroupItemLongClickCommand.Execute(viewHolder.DataContext);
            };

            return viewHolder;
        }

        public override bool OnHookGroupCollapse(int p0, bool p1)
            => GroupExpandController.OnHookGroupCollapse(new MvxHookGroupExpandCollapseArgs
            {
                DataContext = GetItemAt(p0),
                GroupPosition = p0,
                RequestedByUser = p1
            });

        public override bool OnHookGroupExpand(int p0, bool p1)
            => GroupExpandController.OnHookGroupExpand(new MvxHookGroupExpandCollapseArgs
            {
                DataContext = GetItemAt(p0),
                GroupPosition = p0,
                RequestedByUser = p1
            });


        protected virtual View InflateViewForHolder(int layoutId, ViewGroup parent,
            int viewType,
            IMvxAndroidBindingContext bindingContext)
        {
            return bindingContext.BindingInflate(layoutId, parent, false);
        }

        public override void OnBindChildViewHolder(Object viewHolder, int groupPosition, int childPosition, int viewType)
        {
            var dataContext = GetItemAt(groupPosition, childPosition);
            var advancedRecyclerViewHolder = viewHolder as MvxAdvancedRecyclerViewHolder;
            advancedRecyclerViewHolder.DataContext = dataContext;
            OnChildItemBound(new MvxExpandableItemAdapterBoundedArgs
            {
                ViewHolder = viewHolder as MvxExpandableRecyclerViewHolder,
                DataContext = dataContext
            });

            if (ChildSwipeableTemplate != null)
            {
                advancedRecyclerViewHolder.MaxLeftSwipeAmount = ChildSwipeableTemplate.GetMaxLeftSwipeAmount(dataContext, advancedRecyclerViewHolder);
                advancedRecyclerViewHolder.MaxRightSwipeAmount = ChildSwipeableTemplate.GetMaxRightSwipeAmount(dataContext, advancedRecyclerViewHolder);
                // MaxDownSwipeAmount/MaxUpSwipeAmount removed from new library
                
                ChildSwipeableTemplate.SetupUnderSwipeBackground(advancedRecyclerViewHolder);
                ChildSwipeableTemplate.SetupSlideAmount(advancedRecyclerViewHolder, ChildSwipeItemPinnedStateController);
            }
        }

        public override void OnBindGroupViewHolder(Object viewHolder, int groupPosition, int viewType)
        {
            var dataContext = GetItemAt(groupPosition);
            var advancedRecyclerViewHolder = viewHolder as MvxAdvancedRecyclerViewHolder;
            advancedRecyclerViewHolder.DataContext = dataContext;
            OnGroupItemBound(new MvxExpandableItemAdapterBoundedArgs
            {
                ViewHolder = viewHolder as MvxExpandableRecyclerViewHolder,
                DataContext = dataContext
            });
            
            if (GroupSwipeableTemplate != null)
            {
                advancedRecyclerViewHolder.MaxLeftSwipeAmount = GroupSwipeableTemplate.GetMaxLeftSwipeAmount(dataContext, advancedRecyclerViewHolder);
                advancedRecyclerViewHolder.MaxRightSwipeAmount = GroupSwipeableTemplate.GetMaxRightSwipeAmount(dataContext, advancedRecyclerViewHolder);
                // MaxDownSwipeAmount/MaxUpSwipeAmount removed from new library
                
                GroupSwipeableTemplate.SetupUnderSwipeBackground(advancedRecyclerViewHolder);
                GroupSwipeableTemplate.SetupSlideAmount(advancedRecyclerViewHolder, GroupSwipeItemPinnedStateController);
            }
        }

        public override int GetChildCount(int p0)
        {
            if (GroupedItems.Count() <= p0)
                return 0;

            return (GroupedItems.ElementAt(p0) as MvxGroupedData).GroupItems.Count();
        }

        public override long GetChildId(int p0, int p1)
        {
            var childItem = GetItemAt(p0, p1);

            return ExpandableDataConverter.GetItemUniqueId(childItem);
        }

        public override long GetGroupId(int p0)
        {
            var mvxGroupedData = GetItemAt(p0);

            return ExpandableDataConverter.GetItemUniqueId(mvxGroupedData);
        }

        public bool GetInitialGroupExpandedState(int groupPosition)
        {
            return GroupExpandController.GetInitialGroupExpandedState (groupPosition);
        }

        public override void OnViewAttachedToWindow(Object holder)
        {
            base.OnViewAttachedToWindow(holder);

            var viewHolder = (IMvxRecyclerViewHolder)holder;
            viewHolder.OnAttachedToWindow();
        }

        public override void OnViewDetachedFromWindow(Object holder)
        {
            var viewHolder = (IMvxRecyclerViewHolder)holder;

            viewHolder.OnDetachedFromWindow();
            base.OnViewDetachedFromWindow(holder);
        }

        public MvxGroupedData GetItemAt(int groupIndex)
            => GroupedItems.ElementAt(groupIndex) as MvxGroupedData;

        public object GetItemAt(int groupIndex, int childIndex)
            => GetItemAt(groupIndex).GroupItems.ElementAt(childIndex);

        public event Action<MvxExpandableItemAdapterBoundedArgs> GroupItemBound;

        public event Action<MvxExpandableItemAdapterBoundedArgs> ChildItemBound;

        public override int GetGroupItemViewType(int p0) => TemplateSelector.GetItemViewType(GetItemAt(p0));

        public override int GetChildItemViewType(int p0, int p1) => TemplateSelector.GetItemViewType(GetItemAt(p0, p1));

        protected virtual void OnGroupItemBound(MvxExpandableItemAdapterBoundedArgs obj)
        {
            GroupItemBound?.Invoke(obj);
        }

        protected virtual void OnChildItemBound(MvxExpandableItemAdapterBoundedArgs obj)
        {
            ChildItemBound?.Invoke(obj);
        }

        public MvxSwipeableTemplate GroupSwipeableTemplate
        {
            get => groupedSwipeableTemplate ?? _lazyDefaultSwipeableTemplate.Value;
            set => groupedSwipeableTemplate = value;
        }

        public MvxSwipeableTemplate ChildSwipeableTemplate
        {
            get => childSwipeableTemplate ?? _lazyDefaultSwipeableTemplate.Value;
            set => childSwipeableTemplate = value;
        }
  
        public MvxSwipeResultActionFactory GroupSwipeResultActionFactory => GroupSwipeableTemplate?.SwipeResultActionFactory ?? new MvxSwipeResultActionFactory();

        public MvxSwipeResultActionFactory ChildSwipeResultActionFactory => ChildSwipeableTemplate?.SwipeResultActionFactory ?? new MvxSwipeResultActionFactory();

        public SwipeItemPinnedStateControllerProvider GroupSwipeItemPinnedStateController { get; }

        public SwipeItemPinnedStateControllerProvider ChildSwipeItemPinnedStateController { get; } 
        
        public int OnGetChildItemSwipeReactionType(Object p0, int p1, int p2, int x, int y)
        {
            var viewHolder = p0 as MvxExpandableRecyclerViewHolder;

            return (viewHolder.SwipeableContainerView?.HitTest(x, y) ?? false)
                ? ChildSwipeableTemplate.GetSwipeReactionType(viewHolder.DataContext, viewHolder)
                : SwipeableItemConstants.ReactionCanNotSwipeAny;
        }

        public int OnGetGroupItemSwipeReactionType(Object p0, int p1, int x, int y)
        {
            var viewHolder = p0 as MvxExpandableRecyclerViewHolder;
            
            
            return (viewHolder.SwipeableContainerView?.HitTest(x, y) ?? false)
                ? GroupSwipeableTemplate.GetSwipeReactionType(viewHolder.DataContext, viewHolder)
                : SwipeableItemConstants.ReactionCanNotSwipeAny;
        }

        public void OnSetChildItemSwipeBackground(Object p0, int position, int childPosition, int type)
        {
            var advancedViewHolder = p0 as MvxAdvancedRecyclerViewHolder;
            var args = new MvxChildSwipeBackgroundSetEventARgs()
            {
                ViewHolder = advancedViewHolder,
                Position = position,
                ChildPosition = childPosition,
                Type = type
            };
            ChildItemSwipeBackgroundSet?.Invoke(args);
            ChildSwipeableTemplate?.OnSwipeBackgroundSet(args);
        }

        public void OnSetGroupItemSwipeBackground(Object p0, int position, int type)
        {
            var advancedViewHolder = p0 as MvxAdvancedRecyclerViewHolder;
            var args = new MvxGroupSwipeBackgroundSetEventArgs()
            {
                ViewHolder = advancedViewHolder,
                Position = position,
                Type = type
            };
            GroupItemSwipeBackgroundSet?.Invoke(args);
            GroupSwipeableTemplate?.OnSwipeBackgroundSet(args);
        }

        public void OnSwipeChildItemStarted(Object p0, int p1, int p2)
        {
            this.NotifyDataSetChanged();
        }

        public void OnSwipeGroupItemStarted(Object p0, int p1)
        {
            this.NotifyDataSetChanged();
        }

        public int OnSwipeChildItem(Object p0, int groupPosition, int childPosition, int result)
        {
            SwipeResultAction action;
            switch (result)
            {
                case SwipeableItemConstants.ResultSwipedDown:
                    action = ChildSwipeResultActionFactory.GetSwipeDownResultAction(new ExpandableGroupChildSwipeResultActionItemManager(this, groupPosition, childPosition));
                    break;
                case SwipeableItemConstants.ResultSwipedLeft:
                    action = ChildSwipeResultActionFactory.GetSwipeLeftResultAction(new ExpandableGroupChildSwipeResultActionItemManager(this, groupPosition, childPosition));
                    break;
                case SwipeableItemConstants.ResultSwipedRight:
                    action = ChildSwipeResultActionFactory.GetSwipeRightResultAction(new ExpandableGroupChildSwipeResultActionItemManager(this, groupPosition, childPosition));
                    break;
                case SwipeableItemConstants.ResultSwipedUp:
                    action = ChildSwipeResultActionFactory.GetSwipeUpResultAction(new ExpandableGroupChildSwipeResultActionItemManager(this, groupPosition, childPosition));
                    break;
                default:
                    action = groupPosition != RecyclerView.NoPosition && childPosition != RecyclerView.NoPosition ?
                        ChildSwipeResultActionFactory.GetUnpinSwipeResultAction(new ExpandableGroupChildSwipeResultActionItemManager(this, groupPosition, childPosition)) :
                        new SwipeResultActionDoNothing();
                    break;
            }
            _pendingChildSwipeActions[(long)groupPosition << 32 | (uint)childPosition] = action;
            return action._resultCode;
        }

        public int OnSwipeGroupItem(Object p0, int groupPosition, int result)
        {
            SwipeResultAction action;
            switch (result)
            {
                case SwipeableItemConstants.ResultSwipedDown:
                    action = GroupSwipeResultActionFactory.GetSwipeDownResultAction(new ExpandableGroupSwipeResultActionItemManager(this, groupPosition));
                    break;
                case SwipeableItemConstants.ResultSwipedLeft:
                    action = GroupSwipeResultActionFactory.GetSwipeLeftResultAction(new ExpandableGroupSwipeResultActionItemManager(this, groupPosition));
                    break;
                case SwipeableItemConstants.ResultSwipedRight:
                    action = GroupSwipeResultActionFactory.GetSwipeRightResultAction(new ExpandableGroupSwipeResultActionItemManager(this, groupPosition));
                    break;
                case SwipeableItemConstants.ResultSwipedUp:
                    action = GroupSwipeResultActionFactory.GetSwipeUpResultAction(new ExpandableGroupSwipeResultActionItemManager(this, groupPosition));
                    break;
                default:
                    action = groupPosition != RecyclerView.NoPosition ?
                        GroupSwipeResultActionFactory.GetUnpinSwipeResultAction(new ExpandableGroupSwipeResultActionItemManager(this, groupPosition)) :
                        new SwipeResultActionDoNothing();
                    break;
            }
            _pendingGroupSwipeActions[groupPosition] = action;
            return action._resultCode;
        }

        public void OnPerformAfterSwipeChildReaction(Object p0, int groupPosition, int childPosition, int result, int reaction)
        {
            var key = (long)groupPosition << 32 | (uint)childPosition;
            if (_pendingChildSwipeActions.TryGetValue(key, out var action))
            {
                action.PerformAction();
                action.CleanUp();
                _pendingChildSwipeActions.Remove(key);
            }
        }

        public void OnPerformAfterSwipeGroupReaction(Object p0, int groupPosition, int result, int reaction)
        {
            if (_pendingGroupSwipeActions.TryGetValue(groupPosition, out var action))
            {
                action.PerformAction();
                action.CleanUp();
                _pendingGroupSwipeActions.Remove(groupPosition);
            }
        }
        
        public event Action<MvxGroupSwipeBackgroundSetEventArgs> GroupItemSwipeBackgroundSet;

        public event Action<MvxChildSwipeBackgroundSetEventARgs> ChildItemSwipeBackgroundSet;
    }
}