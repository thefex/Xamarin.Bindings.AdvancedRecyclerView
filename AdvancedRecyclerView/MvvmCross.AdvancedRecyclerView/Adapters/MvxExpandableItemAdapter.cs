using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Utils;
using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using MvvmCross.AdvancedRecyclerView.Utils;
using MvvmCross.AdvancedRecyclerView.ViewHolders;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using MvvmCross.Platform;
using MvvmCross.Platform.Exceptions;
using Object = Java.Lang.Object;

namespace MvvmCross.AdvancedRecyclerView.Adapters
{
    public class MvxExpandableItemAdapter : AbstractExpandableItemAdapter
    {
        private readonly MvxExpandableGroupedItemsSourceProvider _expandableGroupedItemsSourceProvider;
        private IEnumerable itemsSource;

        public MvxExpandableItemAdapter() : this(MvxAndroidBindingContextHelpers.Current())
        {
        }

        public MvxExpandableItemAdapter(IMvxAndroidBindingContext androidBindingContext)
        {
            BindingContext = androidBindingContext;
            HasStableIds = true;
            _expandableGroupedItemsSourceProvider = new MvxExpandableGroupedItemsSourceProvider();
            _expandableGroupedItemsSourceProvider.Source.CollectionChanged += SourceOnCollectionChanged;
        }

        protected MvxExpandableItemAdapter(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        protected IMvxAndroidBindingContext BindingContext { get; }

        public MvxExpandableTemplateSelector TemplateSelector { get; set; }

        private ObservableCollection<object> GroupedItems => _expandableGroupedItemsSourceProvider.Source;

        public IEnumerable ItemsSource
        {
            get { return itemsSource; }
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

        public IMvxGroupExpandController GroupExpandController { get; set; } = new DefaultMvxGroupExpandController();

        public override int GroupCount {
            get
            {
                return
                    GroupedItems.Count();
            }
        }

        public IMvxCommand GroupItemClickCommand { get; set; }

        public IMvxCommand GroupItemLongClickCommand { get; set; }

        public IMvxCommand ChildItemClickCommand { get; set; }

        public IMvxCommand ChildItemLongClickCommand { get; set; }

        private void SourceOnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            NotifyDataSetChanged(notifyCollectionChangedEventArgs);
        }

        public virtual void NotifyDataSetChanged(NotifyCollectionChangedEventArgs e)
        {
            try
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        NotifyItemRangeInserted(e.NewStartingIndex, e.NewItems.Count);
                        break;
                    case NotifyCollectionChangedAction.Move:
                        for (var i = 0; i < e.NewItems.Count; i++)
                        {
                            var oldItem = e.OldItems[i];
                            var newItem = e.NewItems[i];

                            NotifyItemMoved(ItemsSource.GetPosition(oldItem), ItemsSource.GetPosition(newItem));
                        }
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        NotifyItemRangeChanged(e.NewStartingIndex, e.NewItems.Count);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        NotifyItemRangeRemoved(e.OldStartingIndex, e.OldItems.Count);
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        NotifyDataSetChanged();
                        break;
                }
            }
            catch (Exception exception)
            {
                Mvx.Warning(
                    "Exception masked during Adapter RealNotifyDataSetChanged {0}. Are you trying to update your collection from a background task? See http://goo.gl/0nW0L6",
                    exception.ToLongString());
            }
        }

        public override bool OnCheckCanExpandOrCollapseGroup(Object holder, int groupPosition, int x, int y, bool expand)
        {
            var groupItemDetails = new MvxGroupDetails
            {
                Holder = holder as RecyclerView.ViewHolder,
                Item = (GroupedItems.ElementAt(groupPosition) as MvxGroupedData),
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
                    InflateViewForHolder(TemplateSelector.GetLayoutId(viewType), parent, viewType, itemBindingContext),
                    itemBindingContext)
                {
                    Click = ChildItemClickCommand,
                    LongClick = ChildItemLongClickCommand
                };

            return viewHolder;
        }

        public override Object OnCreateGroupViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);

            var viewHolder =
                new MvxExpandableRecyclerViewHolder(
                    InflateViewForHolder(TemplateSelector.GetLayoutId(viewType), parent, viewType, itemBindingContext),
                    itemBindingContext)
                {
                    Click = GroupItemClickCommand,
                    LongClick = GroupItemLongClickCommand
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
            (viewHolder as IMvxRecyclerViewHolder).DataContext = dataContext;
            OnChildItemBound(new MvxExpandableItemAdapterBoundedArgs
            {
                ViewHolder = viewHolder as MvxExpandableRecyclerViewHolder,
                DataContext = dataContext
            });
        }

        public override void OnBindGroupViewHolder(Object viewHolder, int groupPosition, int viewType)
        {
            var dataContext = GetItemAt(groupPosition);
            (viewHolder as IMvxRecyclerViewHolder).DataContext = dataContext;
            OnGroupItemBound(new MvxExpandableItemAdapterBoundedArgs
            {
                ViewHolder = viewHolder as MvxExpandableRecyclerViewHolder,
                DataContext = dataContext
            });
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
            
            return ExpandableDataConverter.GetItemUniqueId(GetItemAt(p0, p1));
        }

        public override long GetGroupId(int p0)
        {
            var mvxGroupedData = GetItemAt(p0);

            return ExpandableDataConverter.GetItemUniqueId(mvxGroupedData);
        }

        private MvxGroupedData GetItemAt(int groupIndex)
            => GroupedItems.ElementAt(groupIndex) as MvxGroupedData;

        private object GetItemAt(int groupIndex, int childIndex)
            => GetItemAt(groupIndex).GroupItems.ElementAt(childIndex);

        public event Action<MvxExpandableItemAdapterBoundedArgs> GroupItemBound;

        public event Action<MvxExpandableItemAdapterBoundedArgs> ChildItemBound;

        protected virtual void OnGroupItemBound(MvxExpandableItemAdapterBoundedArgs obj)
        {
            GroupItemBound?.Invoke(obj);
        }

        protected virtual void OnChildItemBound(MvxExpandableItemAdapterBoundedArgs obj)
        {
            ChildItemBound?.Invoke(obj);
        }
    }
}