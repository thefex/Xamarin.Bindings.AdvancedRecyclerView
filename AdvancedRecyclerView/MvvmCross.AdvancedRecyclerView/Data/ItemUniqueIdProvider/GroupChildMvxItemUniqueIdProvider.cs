using MvvmCross.AdvancedRecyclerView.Adapters.Expandable;

namespace MvvmCross.AdvancedRecyclerView.Data.ItemUniqueIdProvider
{
    internal class GroupChildMvxItemUniqueIdProvider : IMvxItemUniqueIdProvider
    {
        private readonly MvxExpandableItemAdapter _expandableItemAdapter;

        public GroupChildMvxItemUniqueIdProvider(MvxExpandableItemAdapter expandableItemAdapter)
        {
            _expandableItemAdapter = expandableItemAdapter;
        }
        
        public long GetUniqueId(object fromObject)
        {
            return _expandableItemAdapter.ExpandableDataConverter.GetItemUniqueId(fromObject);
        }
    }
}