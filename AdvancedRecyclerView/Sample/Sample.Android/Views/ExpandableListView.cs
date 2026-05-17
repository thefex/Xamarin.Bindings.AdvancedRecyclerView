using Android.App;
using MvvmCross.Platforms.Android.Views;
using Sample.Core.ViewModels;

namespace Sample.Android.Views;

[Activity(Label = "@string/title_expandable_list", Theme = "@style/Theme.App")]
public class ExpandableListView : MvxActivity<ExpandableListViewModel>
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_expandable_list);
    }
}
