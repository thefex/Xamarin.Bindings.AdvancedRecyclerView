namespace Sample.Core.Models;

public class CategoryGroup
{
    public string Name { get; set; } = string.Empty;
    public List<GroupedListItem> Items { get; set; } = new();
}
