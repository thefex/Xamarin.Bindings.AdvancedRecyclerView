using System;
using System.Collections.Specialized;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Extensions;
using MvvmCross.AdvancedRecyclerView.Swipe;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions;
using MvvmCross.AdvancedRecyclerView.Swipe.State;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using MvvmCross.AdvancedRecyclerView.ViewHolders;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Object = Java.Lang.Object;

namespace MvvmCross.AdvancedRecyclerView.Adapters
{
    public class MvxAdvancedRecyclerViewAdapter : MvxRecyclerAdapter, ISwipeableItemAdapter
    {
        public MvxAdvancedRecyclerViewAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
        {
            HasStableIds = true;
        }

        public MvxAdvancedRecyclerViewAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            var itemTemplateSelector = ItemTemplateSelector as MvxAdvancedRecyclerViewTemplateSelector;

            var vh = new MvxAdvancedRecyclerViewHolder(InflateViewForHolder(parent, viewType, itemBindingContext),
                itemTemplateSelector.SwipeContainerViewGroupId,
                itemTemplateSelector.UnderSwipeContainerViewGroupId,
                itemBindingContext)
            {
                Click = ItemClick,
                LongClick = ItemLongClick,
                FooterClickCommand = FooterClickCommand,
                HeaderClickCommand = FooterClickCommand,
                GroupHeaderClickCommand = GroupHeaderClickCommand
            };

            return vh;
        }

        public int OnGetSwipeReactionType(Object p0, int p1, int x, int y)
        {
            var viewHolder = p0 as MvxAdvancedRecyclerViewHolder;

            return viewHolder.SwipeableContainerView.HitTest(x, y)
                ? SwipeReactionType
                : SwipeableItemConstants.ReactionCanNotSwipeAny;
        }

        public void OnSetSwipeBackground(Object viewHolder, int position, int type)
        {
            var advancedViewHolder = viewHolder as MvxAdvancedRecyclerViewHolder;
            if (type == SwipeableItemConstants.DrawableSwipeNeutralBackground)
                advancedViewHolder.UnderSwipeableContainerView.Visibility = ViewStates.Gone;
            else
                advancedViewHolder.UnderSwipeableContainerView.Visibility = ViewStates.Visible;
        }

        public SwipeResultAction OnSwipeItem(Object p0, int position, int result)
        {
            switch (result)
            {
                case SwipeableItemConstants.ResultSwipedDown:
                    return SwipeResultActionFactory.GetSwipeDownResultAction(this, position);
                case SwipeableItemConstants.ResultSwipedLeft:
                    return SwipeResultActionFactory.GetSwipeLeftResultAction(this, position);
                case SwipeableItemConstants.ResultSwipedRight:
                    return SwipeResultActionFactory.GetSwipeRightResultAction(this, position);
                case SwipeableItemConstants.ResultSwipedUp:
                    return SwipeResultActionFactory.GetSwipeUpResultAction(this, position);
                default:
                    return position != RecyclerView.NoPosition ? SwipeResultActionFactory.GetUnpinSwipeResultAction(this, position) : new SwipeResultActionDoNothing();
            }
        }

        public override long GetItemId(int position)
        {
            if (UniqueIdProvider == null)
                throw new InvalidOperationException($"You have to assing {nameof(UniqueIdProvider)} property to use AdvancedRecyclerView Adapter");

            var item = GetItem(position);
            return UniqueIdProvider.GetUniqueId(item);
        }

        /// <summary>
        /// Use SwipeableItemConstants.ReactionCan/CanNotSwipe to determine available swipe type.
        /// </summary>
        public int SwipeReactionType { get; set; } = SwipeableItemConstants.ReactionCanSwipeBothH;

        public MvxSwipeResultActionFactory SwipeResultActionFactory { get; set; } = new MvxSwipeResultActionFactory();

        private IMvxItemUniqueIdProvider uniqueIdProvider;
        public IMvxItemUniqueIdProvider UniqueIdProvider
        {
            get { return uniqueIdProvider; }
            set
            {
                uniqueIdProvider = value;
                SwipeItemPinnedStateController.UniqueIdProvider = value;
            }
        }

        public SwipeItemPinnedStateControllerProvider SwipeItemPinnedStateController { get; } = new SwipeItemPinnedStateControllerProvider();

        public override void NotifyDataSetChanged(NotifyCollectionChangedEventArgs e)
        {
            base.NotifyDataSetChanged(e);

            if (e.Action == NotifyCollectionChangedAction.Reset)
                SwipeItemPinnedStateController.ResetState();
        }
    }
}