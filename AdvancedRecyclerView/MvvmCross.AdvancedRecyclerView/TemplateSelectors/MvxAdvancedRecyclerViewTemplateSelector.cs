using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace MvvmCross.AdvancedRecyclerView.TemplateSelectors
{
    public class MvxAdvancedRecyclerViewTemplateSelector : MvxDefaultTemplateSelector
    {
        public MvxAdvancedRecyclerViewTemplateSelector(int itemTemplateId, int swipeContainerViewGroupId, int underSwipeContainerViewGroupId)
            : base(itemTemplateId)
        {
            SwipeContainerViewGroupId = swipeContainerViewGroupId;
            UnderSwipeContainerViewGroupId = underSwipeContainerViewGroupId;
        }

        public int SwipeContainerViewGroupId { get; }

        public int UnderSwipeContainerViewGroupId { get; }
    }
}