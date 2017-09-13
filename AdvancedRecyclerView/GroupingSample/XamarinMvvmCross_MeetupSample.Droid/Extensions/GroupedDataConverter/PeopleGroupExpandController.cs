using System;
using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;
using MvvmCross.AdvancedRecyclerView.Utils;

namespace XamarinMvvmCross_MeetupSample.Droid.Extensions.GroupedDataConverter
{
    public class PeopleGroupExpandController : MvxGroupExpandController
    {
        public PeopleGroupExpandController()
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
