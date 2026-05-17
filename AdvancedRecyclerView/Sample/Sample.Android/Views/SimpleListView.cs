using Android.App;
using MvvmCross.Platforms.Android.Views;
using Sample.Android.Adapters.SimpleList;
using Sample.Core.Models;
using Sample.Core.ViewModels;

namespace Sample.Android.Views;

[Activity(Label = "@string/title_simple_list", Theme = "@style/Theme.App")]
public class SimpleListView : MvxActivity<SimpleListViewModel>
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_simple_list);

        SimpleListSwipeableTemplate.OnDeleteItem = item =>
        {
            if (item is ListItem listItem)
                ViewModel?.DeleteItemCommand.Execute(listItem);
        };
    }
}
