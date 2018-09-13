using MvvmCross.AdvancedRecyclerView.Adapters.Expandable;
using MvvmCross.AdvancedRecyclerView.Swipe.State;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions.ItemManager
{
    internal class ExpandableGroupChildSwipeResultActionItemManager : IMvxSwipeResultActionItemManager
    {
        private readonly MvxExpandableItemAdapter _expandableItemAdapter;
        private readonly int _groupPosition;
        private readonly int _childPosition;

        public ExpandableGroupChildSwipeResultActionItemManager (MvxExpandableItemAdapter expandableItemAdapter, int groupPosition, int childPosition)
        {
            _expandableItemAdapter = expandableItemAdapter;
            _groupPosition = groupPosition;
            _childPosition = childPosition;
        }
        
        public object GetItem()
        {
            return _expandableItemAdapter.GetItemAt(_groupPosition, _childPosition);
        }

        public void NotifyItemChanged()
        {
            _expandableItemAdapter.NotifyDataSetChanged();
        }

        public SwipeItemPinnedStateControllerProvider GetAttachedPinnedStateControllerProviderWithItem()
        {
            return _expandableItemAdapter.ChildSwipeItemPinnedStateController;
        }
    }
}