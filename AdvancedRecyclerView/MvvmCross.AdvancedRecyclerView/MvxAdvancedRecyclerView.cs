using System;
using System.Collections;
using Android.Runtime;
using Android.Support.V7.Widget;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Animator;
using MvvmCross.AdvancedRecyclerView.Adapters;
using MvvmCross.Binding.Droid.BindingContext;

namespace MvvmCross.AdvancedRecyclerView
{
    [Register("mvvmcross.advancedrecyclerview.MvxAdvancedRecyclerView")]
    public sealed class MvxAdvancedRecyclerView : RecyclerView
    {
        private MvxAdvancedRecyclerViewAdapterController adapterController;

        public MvxAdvancedRecyclerView(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MvxAdvancedRecyclerView(Android.Content.Context context, Android.Util.IAttributeSet attrs) : this(context, attrs, 0)
        {
        }

        public MvxAdvancedRecyclerView(Android.Content.Context context, Android.Util.IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            adapterController = new MvxAdvancedRecyclerViewAdapterController();
            var adapter = adapterController.BuildAdapter(context, attrs, this, MvxAndroidBindingContextHelpers.Current());

            var currentLayoutManager = base.GetLayoutManager();

            if (currentLayoutManager == null)
                SetLayoutManager(new LinearLayoutManager(context));

            SetAdapter(adapter);
            SetupDefaultItemAnimator();
            HasFixedSize = false;
        }

        private void SetupDefaultItemAnimator()
        {
            var itemAnimator = new RefactoredDefaultItemAnimator();
            // Change animations are enabled by default since support-v7-recyclerview v22.
            // Need to disable them when using animation indicator.
            itemAnimator.SupportsChangeAnimations = false;
            SetItemAnimator(itemAnimator);
        }

        public IEnumerable ItemsSource
        {
            get { return AdvancedRecyclerViewAdapter.ItemsSource; }
            set { AdvancedRecyclerViewAdapter.ItemsSource = value; }
        }

        public IMvxAdvancedRecyclerViewAdapter AdvancedRecyclerViewAdapter => adapterController.AdvancedRecyclerViewAdapter;
    }
}
