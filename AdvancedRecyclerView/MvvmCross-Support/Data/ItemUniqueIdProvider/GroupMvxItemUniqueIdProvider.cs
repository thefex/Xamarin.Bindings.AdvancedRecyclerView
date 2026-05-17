using MvvmCross.AdvancedRecyclerView.Adapters.Expandable;

namespace MvvmCross.AdvancedRecyclerView.Data.ItemUniqueIdProvider
{
    internal class GroupMvxItemUniqueIdProvider : IMvxItemUniqueIdProvider
    {
        private readonly MvxExpandableItemAdapter _expandableItemAdapter;

        public GroupMvxItemUniqueIdProvider(MvxExpandableItemAdapter expandableItemAdapter)
        {
            _expandableItemAdapter = expandableItemAdapter;
        }
        
        public long GetUniqueId(object fromObject)
        {
            return (fromObject as MvxGroupedData).UniqueId;
        }
    }
}