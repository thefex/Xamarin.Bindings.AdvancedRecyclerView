using System.Collections.ObjectModel;
using System.Collections.Specialized;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Sample.Core.Models;

namespace Sample.Core.ViewModels;

public class SimpleListViewModel : MvxViewModel
{
    private static int _nextId = 6;

    public SimpleListViewModel()
    {
        Items = new ObservableCollection<ListItem>
        {
            new() { Id = 1, Title = "Alpha",   Description = "First item"  },
            new() { Id = 2, Title = "Beta",    Description = "Second item" },
            new() { Id = 3, Title = "Gamma",   Description = "Third item"  },
            new() { Id = 4, Title = "Delta",   Description = "Fourth item" },
            new() { Id = 5, Title = "Epsilon", Description = "Fifth item"  },
        };

        Items.CollectionChanged += (_, _) => RaisePropertyChanged(nameof(HeaderSubtitle));

        AddItemCommand = new MvxCommand(() =>
        {
            int id = _nextId++;
            Items.Add(new ListItem { Id = id, Title = $"Item {id}", Description = $"Dynamically added item #{id}" });
        });

        DeleteItemCommand = new MvxCommand<ListItem>(item => Items.Remove(item));
    }

    public ObservableCollection<ListItem> Items { get; }
    public IMvxCommand AddItemCommand { get; }
    public IMvxCommand<ListItem> DeleteItemCommand { get; }

    public string HeaderTitle => "Simple List";
    public string HeaderSubtitle => $"{Items.Count} items — swipe left to delete";
    public string FooterText => "End of list · Tap 'Add Item' to add more";
}
