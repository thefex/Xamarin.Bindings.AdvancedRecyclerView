namespace MvvmCross.AdvancedRecyclerView.Data
{
    public abstract class MvxExpandableDataConverter
    {
        public abstract MvxGroupedData ConvertToMvxGroupedData(object item);

        public long GetItemUniqueId(object item)
        {
            if (item is MvxGroupedData)
                return ((MvxGroupedData) item).UniqueId;
            return GetChildItemUniqueId(item);
        }

        protected abstract long GetChildItemUniqueId(object item);
    }
}