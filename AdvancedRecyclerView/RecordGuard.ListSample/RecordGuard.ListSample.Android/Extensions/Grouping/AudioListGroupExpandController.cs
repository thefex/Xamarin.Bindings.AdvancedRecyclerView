using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;
using MvvmCross.AdvancedRecyclerView.Utils;

namespace RecordGuard.ListSample.Android.Extensions.Grouping
{
    public class AudioListGroupExpandController : MvxGroupExpandController
    {
        public override bool CanExpandGroup(MvxGroupDetails groupDetails)
        {
            return false;
        }

        public override bool CanCollapseGroup(MvxGroupDetails groupDetails)
        {
            return false;
        }

        public override bool OnHookGroupExpand(MvxHookGroupExpandCollapseArgs groupItemDetails)
        {
            return true;
        }

        public override bool OnHookGroupCollapse(MvxHookGroupExpandCollapseArgs groupItemDetails)
        {
            return true;
        }
    }
}