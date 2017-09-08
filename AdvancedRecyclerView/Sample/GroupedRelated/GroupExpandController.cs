using System;
using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;
using MvvmCross.AdvancedRecyclerView.Utils;

namespace Sample.GroupedRelated
{
    public class GroupExpandController : IMvxGroupExpandController
    {
        public GroupExpandController()
        {
        }

        public bool CanCollapseGroup(MvxGroupDetails groupDetails)
        {
            return true;
        }

        public bool CanExpandGroup(MvxGroupDetails groupDetails)
        {
            return true;
        }

        public bool OnHookGroupCollapse(MvxHookGroupExpandCollapseArgs groupItemDetails)
        {
            return true;
        }

        public bool OnHookGroupExpand(MvxHookGroupExpandCollapseArgs groupItemDetails)
        {
            return true;
        }
    }
}
