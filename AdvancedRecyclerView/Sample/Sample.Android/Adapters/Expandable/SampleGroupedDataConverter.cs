using MvvmCross.AdvancedRecyclerView.Data;
using Sample.Core.Models;

namespace Sample.Android.Adapters.Expandable;

public class SampleGroupedDataConverter : MvxExpandableDataConverter
{
    public override MvxGroupedData ConvertToMvxGroupedData(object item)
    {
        var group = (CategoryGroup)item;
        return new MvxGroupedData
        {
            Key = group.Name,
            UniqueId = group.Name.GetHashCode(),
            GroupItems = group.Items,
        };
    }

    protected override long GetChildItemUniqueId(object item)
        => item is GroupedListItem child ? child.Id : item.GetHashCode();
}
