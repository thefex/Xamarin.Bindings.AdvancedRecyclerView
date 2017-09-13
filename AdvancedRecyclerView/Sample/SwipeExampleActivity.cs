using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Animator;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Touchguard;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Utils;
using MvvmCross.AdvancedRecyclerView;
using MvvmCross.AdvancedRecyclerView.Adapters;
using MvvmCross.AdvancedRecyclerView.Adapters.NonExpandable;
using MvvmCross.AdvancedRecyclerView.Swipe;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using MvvmCross.AdvancedRecyclerView.ViewHolders;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using Sample.Swipe;
using Sample.ViewModels;

namespace Sample
{
    [Activity(Label = "Swipe Example", Theme="@style/appThemeBase")]

    public class SwipeExampleActivity : MvxAppCompatActivity<SwipeExampleViewModel>
    {
        private MvxAdvancedNonExpandableRecyclerView mRecyclerView;
       
        public SwipeExampleActivity()
        {
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.swipe_example);

            mRecyclerView = FindViewById<MvxAdvancedNonExpandableRecyclerView>(Resource.Id.RecyclerView);

            var mAdapter = mRecyclerView.AdvancedRecyclerViewAdapter as MvxNonExpandableAdapter;
            mAdapter.SwipeResultActionFactory = new SwipeResultActionFactory();

            mAdapter.MvxViewHolderBound += (args) =>
            {
                var swipeHolder = args.Holder as MvxAdvancedRecyclerViewHolder;
                var swipeState = swipeHolder.SwipeStateFlags;

                if ((swipeState & SwipeableItemConstants.StateFlagIsUpdated & 0) == 0)
                {
                    int backgroundResourceId;
                    if ((swipeState & SwipeableItemConstants.StateFlagIsActive) != 0)
                        backgroundResourceId = Resource.Drawable.bg_item_swiping_active_state;
                    else if ((swipeState & SwipeableItemConstants.StateFlagSwiping) != 0)
                        backgroundResourceId = Resource.Drawable.bg_item_swiping_state;
                    else
                        backgroundResourceId = Resource.Drawable.bg_item_normal_state;
                    swipeHolder.UnderSwipeableContainerView.SetBackgroundResource(backgroundResourceId);
                }

                swipeHolder.MaxLeftSwipeAmount = -0.5f;
                swipeHolder.MaxRightSwipeAmount = 0;

                swipeHolder.SwipeItemHorizontalSlideAmount =
                    mAdapter.SwipeItemPinnedStateController.ForRightSwipe().IsPinned(args.DataContext) ? -0.5f : 0;
            };
            
            mAdapter.SwipeBackgroundSet += (args) =>
			{
				int bgRes = 0;
				switch (args.Type)
				{
					case SwipeableItemConstants.DrawableSwipeNeutralBackground:
						bgRes = Resource.Drawable.bg_swipe_item_neutral;
						break;
					case SwipeableItemConstants.DrawableSwipeLeftBackground:
                        bgRes = Resource.Drawable.bg_item_swiping_state;
						break;
				}

				if (bgRes != 0)
					args.ViewHolder.ItemView.SetBackgroundResource(bgRes);
			};
        }


    }
}