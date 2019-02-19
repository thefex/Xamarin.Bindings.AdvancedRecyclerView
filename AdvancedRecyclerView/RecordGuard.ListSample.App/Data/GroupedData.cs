using System.Collections.Generic;

namespace RecordGuard.ListSample.App.Data
{
    public class GroupedData<TKey, TItem>
    {
        public TKey Key { get; set; }
        
        public IEnumerable<TItem> ChildItems { get; set; }
    }
}