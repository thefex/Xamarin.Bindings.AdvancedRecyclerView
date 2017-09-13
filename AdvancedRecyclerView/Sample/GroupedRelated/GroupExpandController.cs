using System;
using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;
using MvvmCross.AdvancedRecyclerView.Utils;

namespace Sample.GroupedRelated
{
    public class GroupExpandController : MvxGroupExpandController
    {
        public GroupExpandController()
        {
        }

        public override bool CanCollapseGroup(MvxGroupDetails groupDetails)
        {
            return true;
        }

        public override bool CanExpandGroup(MvxGroupDetails groupDetails)
        {
            return true;
        }

        public override bool OnHookGroupCollapse(MvxHookGroupExpandCollapseArgs groupItemDetails)
        {
            return true;
        }

        public override bool OnHookGroupExpand(MvxHookGroupExpandCollapseArgs groupItemDetails)
        {
            return true;
        }
    }
}
