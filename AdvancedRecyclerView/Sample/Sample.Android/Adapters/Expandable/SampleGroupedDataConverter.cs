using MvvmCross.AdvancedRecyclerView.Data;
using Sample.Core.Models;

namespace Sample.Android.Adapters.Expandable;

public class SampleGroupedDataConverter : MvxExpandableDataConverter
{
    Dictionary<string, long> _nameToGroupIdMap = new Dictionary<string, long>();
    private long currentId;
    public override MvxGroupedData ConvertToMvxGroupedData(object item)
    {
        var groupId = 0l;
            
        var group = (CategoryGroup)item;
        if (_nameToGroupIdMap.ContainsKey(group.Name))
            groupId = _nameToGroupIdMap[group.Name];
        else
        {
            groupId = currentId++;
            _nameToGroupIdMap[group.Name] = groupId;
        }
        
        return new MvxGroupedData
        {
            Key = group.Name,
            UniqueId = groupId,
            GroupItems = group.Items,
        };
    }

    protected override long GetChildItemUniqueId(object item)
        => item is GroupedListItem child ? child.Id : item.GetHashCode();
}
