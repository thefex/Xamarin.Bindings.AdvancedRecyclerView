using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions.ItemManager;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions
{
    public class MvxSwipeUnpinResultAction : SwipeResultActionDefault
    {
        private IMvxSwipeResultActionItemManager _itemManager;

        public MvxSwipeUnpinResultAction(IMvxSwipeResultActionItemManager itemManager)
        {
            _itemManager = itemManager;
        }

        protected override void OnPerformAction()
        {

            var item = _itemManager.GetItem();
            var swipeItemPinedStateControlerProvider = _itemManager.GetAttachedPinnedStateControllerProviderWithItem();
            
            if (swipeItemPinedStateControlerProvider.IsPinnedForAnyState(item))
            {
                swipeItemPinedStateControlerProvider.SetPinnedForAllStates(item, false);
                _itemManager.NotifyItemChanged();
            }
        }

        protected override void OnCleanUp()
        {
            _itemManager = null;
        }
    }
}