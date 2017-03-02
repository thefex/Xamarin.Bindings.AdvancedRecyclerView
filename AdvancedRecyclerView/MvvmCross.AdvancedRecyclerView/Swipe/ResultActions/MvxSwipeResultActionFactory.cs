using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using MvvmCross.AdvancedRecyclerView.Adapters;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions
{
    public class MvxSwipeResultActionFactory
    {
        public virtual SwipeResultAction GetSwipeUpResultAction(MvxAdvancedRecyclerViewAdapter adapter, int position)
        {
            return new SwipeResultActionDoNothing();
        }

        public virtual SwipeResultAction GetSwipeDownResultAction(MvxAdvancedRecyclerViewAdapter adapter, int position)
        {
            return new SwipeResultActionDoNothing();
        }
        public virtual SwipeResultAction GetSwipeLeftResultAction(MvxAdvancedRecyclerViewAdapter adapter, int position)
        {
            return new SwipeResultActionDoNothing();
        }
        public virtual SwipeResultAction GetSwipeRightResultAction(MvxAdvancedRecyclerViewAdapter adapter, int position)
        {
            return new SwipeResultActionDoNothing();
        }
        public virtual SwipeResultAction GetUnpinSwipeResultAction(MvxAdvancedRecyclerViewAdapter adapter, int position)
        {
            return new SwipeResultActionDoNothing();
        }
    }
}