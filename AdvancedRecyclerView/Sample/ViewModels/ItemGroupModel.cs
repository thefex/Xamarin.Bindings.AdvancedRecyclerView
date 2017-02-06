using System.Collections.Generic;

namespace Sample.ViewModels
{
    public class ItemGroupModel
    {
        public ItemGroupModel(int index)
        {
            Header = "Group " + index;
            UniqueId = index;
            Child = new List<ChildItemModel>();
        }

        public string Header { get; }

        public IList<ChildItemModel> Child { get; }

        public long UniqueId { get; }
    }

    public class ChildItemModel
    {
        public string Text { get; set; }

        public long UniqueId { get; set; }
    }
}