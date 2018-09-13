using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using MvvmCross.AdvancedRecyclerView.Adapters;
using MvvmCross.AdvancedRecyclerView.Adapters.NonExpandable;
using MvvmCross.AdvancedRecyclerView.Swipe;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions.ItemManager;

namespace Sample.Swipe
{
    class SwipeResultActionFactory : MvxSwipeResultActionFactory
    {
        public override SwipeResultAction GetSwipeLeftResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new MvxSwipeToDirectionResultAction(itemProvider, SwipeDirection.FromRight);
        }

        public override SwipeResultAction GetSwipeRightResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new MvxSwipeUnpinResultAction(itemProvider);
        }

        public override SwipeResultAction GetUnpinSwipeResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            return new MvxSwipeUnpinResultAction(itemProvider);
        }
    }
}