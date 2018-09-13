using MvvmCross.AdvancedRecyclerView.Adapters.Expandable;
using MvvmCross.AdvancedRecyclerView.Swipe.State;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions.ItemManager
{
    internal class ExpandableGroupSwipeResultActionItemManager : IMvxSwipeResultActionItemManager
    {
        private readonly MvxExpandableItemAdapter _expandableItemAdapter;
        private readonly int _groupPosition;

        public ExpandableGroupSwipeResultActionItemManager(MvxExpandableItemAdapter expandableItemAdapter, int groupPosition)
        {
            _expandableItemAdapter = expandableItemAdapter;
            _groupPosition = groupPosition;
        }
        
        public object GetItem()
        {
            return _expandableItemAdapter.GetItemAt(_groupPosition);
        }

        public void NotifyItemChanged()
        {
            _expandableItemAdapter.NotifyDataSetChanged();
        }

        public SwipeItemPinnedStateControllerProvider GetAttachedPinnedStateControllerProviderWithItem()
        {
            return _expandableItemAdapter.GroupSwipeItemPinnedStateController;
        }
    }
}