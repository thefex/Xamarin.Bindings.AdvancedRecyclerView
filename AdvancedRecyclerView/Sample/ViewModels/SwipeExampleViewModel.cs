using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;

namespace Sample.ViewModels
{
    public class SwipeExampleViewModel : MvxViewModel
    {
        public SwipeExampleViewModel()
        {
            Items = new ObservableCollection<SwipeItemModel>()
            {
 
            };

            for (int i = 0; i < 50; ++i)
            {
                Items.Add(new SwipeItemModel()
                {
                    Id = i+1,
                    Title = "test " + (i+1)
                });
            }
        }

        public ObservableCollection<SwipeItemModel> Items { get; }
    }

    public class SwipeItemModel
    {
        public string Title { get; set; }

        public long Id { get; set; }
    }
}