using MvvmCross.AdvancedRecyclerView.Swipe.State;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions.ItemManager
{
    public interface IMvxSwipeResultActionItemManager
    {
        object GetItem();
        void NotifyItemChanged();

        SwipeItemPinnedStateControllerProvider GetAttachedPinnedStateControllerProviderWithItem();
    }
}