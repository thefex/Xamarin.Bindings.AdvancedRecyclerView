using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sample.ViewModels
{
    public class ItemGroupModel
    {
        public ItemGroupModel(int index)
        {
            Header = "Group " + index;
            UniqueId = index;
            Child = new ObservableCollection<ChildItemModel>();
        }

        public string Header { get; }

        public ObservableCollection<ChildItemModel> Child { get; }

        public long UniqueId { get; }
    }

    public class ChildItemModel
    {
        public string Text { get; set; }

        public long UniqueId { get; set; }
    }
}