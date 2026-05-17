using System.Collections;

namespace MvvmCross.AdvancedRecyclerView.Data
{
    public class MvxGroupedData
    {
        public object Key { get; set; }

        public IEnumerable GroupItems { get; set; }

        public long UniqueId { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as MvxGroupedData;
            return other != null && other.UniqueId == this.UniqueId;
        }

        public override int GetHashCode()
        {
            return UniqueId.GetHashCode();
        }
    }
}