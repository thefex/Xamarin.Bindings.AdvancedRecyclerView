using System;
using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;
using MvvmCross.AdvancedRecyclerView.Utils;

namespace XamarinMvvmCross_MeetupSample.Droid.Extensions.GroupedDataConverter
{
    public class PeopleGroupExpandController : IMvxGroupExpandController
    {
        public PeopleGroupExpandController()
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
