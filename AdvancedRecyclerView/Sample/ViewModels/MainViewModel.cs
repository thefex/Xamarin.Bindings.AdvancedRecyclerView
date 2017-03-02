using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace Sample.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MainViewModel()
        {
            var itemGroupModels = new List<ItemGroupModel>();
            itemGroupModels.Add(new ItemGroupModel(0)
            {
                Child =
                {
                    new ChildItemModel() { Text = "test 1", UniqueId = 1},
                    new ChildItemModel() { Text = "test 1", UniqueId = 2},
                    new ChildItemModel() { Text = "test 1", UniqueId = 3},
                    new ChildItemModel() { Text = "test 1", UniqueId = 4},
                    new ChildItemModel() { Text = "test 1", UniqueId = 5},
                    new ChildItemModel() { Text = "test 1", UniqueId = 6},
                    new ChildItemModel() { Text = "test 1", UniqueId = 7},
                    new ChildItemModel() { Text = "test 1", UniqueId = 8},
                    new ChildItemModel() { Text = "test 1", UniqueId = 9}
                },
            });
            itemGroupModels.Add(new ItemGroupModel(10)
            {
                Child =
                {
                    new ChildItemModel() { Text = "test 1", UniqueId = 11},
                    new ChildItemModel() { Text = "test 1", UniqueId = 12},
                    new ChildItemModel() { Text = "test 1", UniqueId = 13},
                    new ChildItemModel() { Text = "test 1", UniqueId = 14},
                    new ChildItemModel() { Text = "test 1", UniqueId = 15},
                    new ChildItemModel() { Text = "test 1", UniqueId = 16},
                    new ChildItemModel() { Text = "test 1", UniqueId = 17},
                    new ChildItemModel() { Text = "test 1", UniqueId = 18},
                    new ChildItemModel() { Text = "test 1", UniqueId = 19}
                }
            });
            Items = itemGroupModels;
        }


        public IEnumerable<ItemGroupModel> Items { get; }

        public MvxCommand GoToSwipeExample => new MvxCommand(() => ShowViewModel<SwipeExampleViewModel>());
    }
}