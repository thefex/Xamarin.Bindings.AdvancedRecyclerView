using MvvmCross.AdvancedRecyclerView.Adapters.NonExpandable;
using MvvmCross.AdvancedRecyclerView.Swipe.State;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions.ItemManager
{
    internal class NonExpandableSwipeResultActionItemManager : IMvxSwipeResultActionItemManager
    {
        private readonly MvxNonExpandableAdapter _nonExpandableAdapter;
        private readonly int _itemPosition;

        public NonExpandableSwipeResultActionItemManager(MvxNonExpandableAdapter nonExpandableAdapter, int itemPosition)
        {
            _nonExpandableAdapter = nonExpandableAdapter;
            _itemPosition = itemPosition;
        }
        
        public object GetItem() => _nonExpandableAdapter.GetItem(_itemPosition);

        public void NotifyItemChanged() => _nonExpandableAdapter.NotifyItemChanged(_itemPosition);

        public SwipeItemPinnedStateControllerProvider GetAttachedPinnedStateControllerProviderWithItem() => _nonExpandableAdapter.SwipeItemPinnedStateController;
    }
}