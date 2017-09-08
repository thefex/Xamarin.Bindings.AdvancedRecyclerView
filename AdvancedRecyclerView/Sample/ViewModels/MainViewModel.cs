using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MvvmCross.Core.ViewModels;

namespace Sample.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MainViewModel()
        {
            var itemGroupModels = new ObservableCollection<ItemGroupModel>();
            itemGroupModels.Add(new ItemGroupModel(0)
            {
                Child =
                {
                    new ChildItemModel() { Text = "-1", UniqueId = 1},
                }
            });
            itemGroupModels.Add(new ItemGroupModel(10)
            {
                Child =
                {
                    new ChildItemModel() { Text = "-2" }
                }
            });
            Items = itemGroupModels;
        }


        public ObservableCollection<ItemGroupModel> Items { get; }

        public MvxCommand AddItems => new MvxCommand(() =>
        {
            for (int i = 0; i < 5; ++i)
            {
                Items.FirstOrDefault().Child.Add(new ChildItemModel() { Text = i.ToString(), UniqueId = i + 100 });

            }
        });

        int groupId = 100;
        public MvxCommand AddGroup => new MvxCommand(() =>
        {
            groupId++;
            var group = new ItemGroupModel(groupId)
            {
                Child =
                {
                    new ChildItemModel() { Text = "test 1" + groupId, UniqueId = 11},
                }
            };
            Items.Add(group);
        });
        public MvxCommand GoToSwipeExample => new MvxCommand(() => ShowViewModel<SwipeExampleViewModel>());
    }
}