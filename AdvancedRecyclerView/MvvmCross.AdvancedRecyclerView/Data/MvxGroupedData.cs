using System.Collections;

namespace MvvmCross.AdvancedRecyclerView.Data
{
    public class MvxGroupedData
    {
        public object Key { get; set; }

        public IEnumerable GroupItems { get; set; }

        public long UniqueId { get; set; }
    }
}