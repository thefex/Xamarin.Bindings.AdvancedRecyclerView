using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;

namespace MvvmCross.AdvancedRecyclerView.Utils
{
    internal class DefaultMvxGroupExpandController : IMvxGroupExpandController
    {
        public bool CanExpandGroup(MvxGroupDetails groupDetails) => true;
        public bool CanCollapseGroup(MvxGroupDetails groupDetails) => true;
        public bool OnHookGroupExpand(MvxHookGroupExpandCollapseArgs groupItemDetails) => true;

        public bool OnHookGroupCollapse(MvxHookGroupExpandCollapseArgs groupItemDetails) => true;
    }
}