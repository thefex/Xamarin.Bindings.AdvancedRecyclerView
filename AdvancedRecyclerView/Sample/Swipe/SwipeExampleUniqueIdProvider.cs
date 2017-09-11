using System;
using MvvmCross.AdvancedRecyclerView.Data;
using Sample.ViewModels;

namespace Sample.Swipe
{
    class SwipeExampleUniqueIdProvider : IMvxItemUniqueIdProvider
    {
        public long GetUniqueId(object fromObject)
        {
            return (fromObject as SwipeItemModel).Id;
        }
    }
}