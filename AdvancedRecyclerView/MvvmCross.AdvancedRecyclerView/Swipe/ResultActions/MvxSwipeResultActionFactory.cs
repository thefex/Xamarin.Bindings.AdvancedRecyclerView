using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using MvvmCross.AdvancedRecyclerView.Adapters;
using MvvmCross.AdvancedRecyclerView.Adapters.NonExpandable;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions.ItemManager;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions
{
    public class MvxSwipeResultActionFactory
    {
        public virtual SwipeResultAction GetSwipeUpResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new SwipeResultActionDoNothing();
        }

        public virtual SwipeResultAction GetSwipeDownResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new SwipeResultActionDoNothing();
        }
        public virtual SwipeResultAction GetSwipeLeftResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new SwipeResultActionDoNothing();
        }
        public virtual SwipeResultAction GetSwipeRightResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new SwipeResultActionDoNothing();
        }
        public virtual SwipeResultAction GetUnpinSwipeResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new SwipeResultActionDoNothing();
        }
    }
}