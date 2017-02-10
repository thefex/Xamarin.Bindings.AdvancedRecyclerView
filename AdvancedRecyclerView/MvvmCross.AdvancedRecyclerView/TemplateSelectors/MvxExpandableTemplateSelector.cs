using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace MvvmCross.AdvancedRecyclerView.TemplateSelectors
{
    public abstract class MvxExpandableTemplateSelector : MvxBaseTemplateSelector
    {
        private const int GroupViewType = 12345276;

        protected MvxExpandableTemplateSelector(int groupLayoutId)
        {
            GroupLayoutId = groupLayoutId;
        }

        public int GroupLayoutId { get; }

        protected override int GetItemViewType(object forItemObject)
        {
            if (forItemObject is MvxGroupedData)
                return GroupViewType;

            return GetChildItemViewType(forItemObject);
        }

        protected override int GetItemLayoutId(int fromViewType)
        {
            if (fromViewType == GroupViewType)
                return GroupLayoutId;

            return GetChildItemLayoutId(fromViewType);
        }

        protected abstract int GetChildItemViewType(object forItemObject);

        protected abstract int GetChildItemLayoutId(int fromViewType);
    }
}