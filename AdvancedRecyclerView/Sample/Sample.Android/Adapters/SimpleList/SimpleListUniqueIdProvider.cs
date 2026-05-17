using MvvmCross.AdvancedRecyclerView.Data.ItemUniqueIdProvider;
using Sample.Core.Models;

namespace Sample.Android.Adapters.SimpleList;

public class SimpleListUniqueIdProvider : IMvxItemUniqueIdProvider
{
    public long GetUniqueId(object fromObject)
        => fromObject is ListItem item ? item.Id : fromObject.GetHashCode();
}
