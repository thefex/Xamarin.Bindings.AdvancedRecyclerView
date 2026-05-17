using System.Collections.ObjectModel;
using MvvmCross.ViewModels;
using Sample.Core.Models;

namespace Sample.Core.ViewModels;

public class ExpandableListViewModel : MvxViewModel
{
    public ExpandableListViewModel()
    {
        Items = new ObservableCollection<CategoryGroup>
        {
            new()
            {
                Name = "Fruits",
                Items = new List<GroupedListItem>
                {
                    new() { Id = 1, Title = "Apple",  Category = "Fruits" },
                    new() { Id = 2, Title = "Banana", Category = "Fruits" },
                    new() { Id = 3, Title = "Cherry", Category = "Fruits" },
                }
            },
            new()
            {
                Name = "Vegetables",
                Items = new List<GroupedListItem>
                {
                    new() { Id = 4, Title = "Broccoli", Category = "Vegetables" },
                    new() { Id = 5, Title = "Carrot",   Category = "Vegetables" },
                    new() { Id = 6, Title = "Spinach",  Category = "Vegetables" },
                }
            },
            new()
            {
                Name = "Dairy",
                Items = new List<GroupedListItem>
                {
                    new() { Id = 7, Title = "Milk",   Category = "Dairy" },
                    new() { Id = 8, Title = "Cheese", Category = "Dairy" },
                    new() { Id = 9, Title = "Yogurt", Category = "Dairy" },
                }
            },
            new()
            {
                Name = "Meat",
                Items = new List<GroupedListItem>
                {
                    new() { Id = 10, Title = "Chicken", Category = "Meat" },
                    new() { Id = 11, Title = "Beef",    Category = "Meat" },
                }
            },
        };
    }

    public ObservableCollection<CategoryGroup> Items { get; }

    public string HeaderTitle => "Food Categories";
    public string HeaderSubtitle => $"{Items.Count} groups · tap a group to expand";
    public string FooterText => "End of list · only one group expands at a time (Accordion)";
}
