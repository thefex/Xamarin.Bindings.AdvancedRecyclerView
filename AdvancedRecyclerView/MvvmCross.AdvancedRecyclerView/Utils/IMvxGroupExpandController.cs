using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;

namespace MvvmCross.AdvancedRecyclerView.Utils
{
    public interface IMvxGroupExpandController
    {
        bool CanExpandGroup(MvxGroupDetails groupDetails);

        bool CanCollapseGroup(MvxGroupDetails groupDetails);

        bool OnHookGroupExpand(MvxHookGroupExpandCollapseArgs groupItemDetails);

        bool OnHookGroupCollapse(MvxHookGroupExpandCollapseArgs groupItemDetails);
    }


}