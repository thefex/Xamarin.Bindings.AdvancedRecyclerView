using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.View.Menu;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.AdvancedRecyclerView;
using MvvmCross.AdvancedRecyclerView.Adapters.Expandable;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using RecordGuard.ListSample.Android.Extensions.CustomViews;
using RecordGuard.ListSample.Android.Extensions.Listeners;
using RecordGuard.ListSample.Android.ViewControllers;
using RecordGuard.ListSample.App.ViewModel;

namespace RecordGuard.ListSample.Android.Activities
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait, WindowSoftInputMode = SoftInput.AdjustPan, ClearTaskOnLaunch = true, LaunchMode = LaunchMode.SingleTask,
        Theme = "@style/appTheme")]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        EmptyListAnimationController _emptyListAnimationController;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            SetupRecyclerView();

            ViewModel.Load(); 
            
            var emptyView = FindViewById(Resource.Id.emptyViewLayout);
            var listView = FindViewById(Resource.Id.recyclerView);
            _emptyListAnimationController = new EmptyListAnimationController(emptyView, listView);

            var set = this.CreateBindingSet<MainActivity, MainViewModel>();

            set.Bind(_emptyListAnimationController)
                .For(x => x.HasAnyItems)
                .To(x => x.HasAnyItems);

            set.Apply();

            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.PostDelayed(() =>
            {
                fab.Show();
            }, 75);
        }
        
        private void SetupRecyclerView()
        {
            var recyclerView = FindViewById<MvxAdvancedRecyclerView>(Resource.Id.recyclerView);

            var mvxExpandableItemAdapter = recyclerView.AdvancedRecyclerViewAdapter as MvxExpandableItemAdapter;
            mvxExpandableItemAdapter.ChildItemBound += (args) =>
            {
                var playPauseView = args.ViewHolder.ItemView.FindViewById<PlayPauseView>(Resource.Id.play_pause_view);
                playPauseView.SetOnClickListener(new ActionClickListenerWrapper(x =>
                {
                    ViewModel.ItemTapped.Execute(args.DataContext);
                }));

                var overflowMenuView = args.ViewHolder.ItemView.FindViewById(Resource.Id.overflow_item);
                overflowMenuView.SetOnClickListener(new ActionClickListenerWrapper(x =>
                {
                    var overflowMenu = new PopupMenu(this, overflowMenuView);
                    overflowMenu.MenuInflater.Inflate(Resource.Menu.audio_item_menu, overflowMenu.Menu);

                    MenuPopupHelper helper = new MenuPopupHelper(this, (MenuBuilder) overflowMenu.Menu);
                    helper.SetAnchorView(overflowMenuView);
                    helper.SetForceShowIcon(true);
                    helper.Show();

                    overflowMenu.MenuItemClick += (sender, menuArgs) =>
                    {
                        overflowMenu.Dismiss();
                    };
                }));
            };

            mvxExpandableItemAdapter.ChildSwipeItemPinnedStateController.ForLeftSwipe().Pinned += (item) =>
                {
                    ViewModel.PinToDelete.Execute(item);
                };
        }

    }
}