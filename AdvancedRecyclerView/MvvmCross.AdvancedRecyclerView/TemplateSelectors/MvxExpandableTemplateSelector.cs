using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace MvvmCross.AdvancedRecyclerView.TemplateSelectors
{
    public abstract class MvxExpandableTemplateSelector : IMvxTemplateSelector
    {
        private const int GroupViewType = 12345276;

        protected MvxExpandableTemplateSelector(int groupLayoutId)
        {
            GroupLayoutId = groupLayoutId;
        }

        public int GroupLayoutId { get; }

        public int GetItemViewType(object forItemObject)
        {
            if (forItemObject is MvxGroupedData)
                return GroupViewType;

            return GetChildItemViewType(forItemObject);
        }

        public int GetItemLayoutId(int fromViewType)
        {
            if (fromViewType == GroupViewType)
                return GroupLayoutId;

            return GetChildItemLayoutId(fromViewType);
        }

        protected abstract int GetChildItemViewType(object forItemObject);

        protected abstract int GetChildItemLayoutId(int fromViewType);
    }
}