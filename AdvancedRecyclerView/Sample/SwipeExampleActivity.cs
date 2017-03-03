using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Animator;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Touchguard;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Utils;
using MvvmCross.AdvancedRecyclerView.Adapters;
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
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private MvxAdvancedRecyclerViewAdapter mAdapter;
        private RecyclerView.Adapter mWrappedAdapter;
        private RecyclerViewSwipeManager mRecyclerViewSwipeManager;
        private RecyclerViewTouchActionGuardManager mRecyclerViewTouchActionGuardManager;

        public SwipeExampleActivity()
        {
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.swipe_example);

            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerView);
            mLayoutManager = new LinearLayoutManager(this);

            mRecyclerViewTouchActionGuardManager = new RecyclerViewTouchActionGuardManager();
            mRecyclerViewTouchActionGuardManager.SetInterceptVerticalScrollingWhileAnimationRunning(true);
            mRecyclerViewTouchActionGuardManager.Enabled = true;

            mRecyclerViewSwipeManager = new RecyclerViewSwipeManager();

            mAdapter = new MvxAdvancedRecyclerViewAdapter((IMvxAndroidBindingContext) BindingContext)
            {
                ItemTemplateSelector =
                    new MvxAdvancedRecyclerViewTemplateSelector(Resource.Layout.swipe_item_template,
                        Resource.Id.container,
                        Resource.Id.underSwipe)
            };
            mAdapter.UniqueIdProvider = new SwipeExampleUniqueIdProvider();
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


            mWrappedAdapter = mRecyclerViewSwipeManager.CreateWrappedAdapter(mAdapter);

            GeneralItemAnimator animator = new SwipeDismissItemAnimator();
            animator.SupportsChangeAnimations = (false);

            mRecyclerView.SetLayoutManager(mLayoutManager);
            mRecyclerView.SetAdapter(mWrappedAdapter);
            mRecyclerView.SetItemAnimator(animator);

            mRecyclerViewTouchActionGuardManager.AttachRecyclerView(mRecyclerView);
            mRecyclerViewSwipeManager.AttachRecyclerView(mRecyclerView);

            var bindingSet = this.CreateBindingSet<SwipeExampleActivity, SwipeExampleViewModel>();

            bindingSet.Bind(mAdapter)
                .For(x => x.ItemsSource)
                .To(x => x.Items);

            bindingSet.Apply();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            mRecyclerViewSwipeManager?.Release();
            mRecyclerViewTouchActionGuardManager?.Release();
            mRecyclerView?.SetItemAnimator(null);
            mRecyclerView?.SetAdapter(null);

            if (mWrappedAdapter!=null)
                WrapperAdapterUtils.ReleaseAll(mWrappedAdapter);
 
        }
    }
}