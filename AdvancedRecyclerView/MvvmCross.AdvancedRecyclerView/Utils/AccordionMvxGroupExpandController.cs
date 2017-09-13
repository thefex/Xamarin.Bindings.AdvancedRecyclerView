using System;
using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;

namespace MvvmCross.AdvancedRecyclerView.Utils
{
    public class AccordionMvxGroupExpandController : MvxGroupExpandController
    {
        int currentlyExpandedIndex = -1;

        public AccordionMvxGroupExpandController()
        {
        }

        public override bool AreGroupsExpandedByDefault => false;

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
			currentlyExpandedIndex = -1;
            return true;
		}

        public override bool OnHookGroupExpand(MvxHookGroupExpandCollapseArgs groupItemDetails)
        {
			if (currentlyExpandedIndex != -1)
                ExpandableItemManager.CollapseGroup(currentlyExpandedIndex);

            currentlyExpandedIndex = groupItemDetails.GroupPosition;

            if (ItemHeight.HasValue)
                ExpandableItemManager.ScrollToGroup(currentlyExpandedIndex, ItemHeight.Value, 20, 20);

            return true;
        }

        public int? ItemHeight { get; set; }
    }
}
