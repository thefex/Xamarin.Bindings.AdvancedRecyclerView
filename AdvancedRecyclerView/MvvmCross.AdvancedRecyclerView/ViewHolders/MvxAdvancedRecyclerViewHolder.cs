using System;
using Android.Views;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MvvmCross.AdvancedRecyclerView.ViewHolders
{
    public class MvxAdvancedRecyclerViewHolder : MvxRecyclerViewHolder, ISwipeableItemViewHolder
    {
        public MvxAdvancedRecyclerViewHolder(View itemView, int swipeableContainerViewId, int underSwipeContainerViewId, IMvxAndroidBindingContext context)
            : base(itemView, context)
        {
            SwipeableContainerView = itemView.FindViewById(swipeableContainerViewId);
            UnderSwipeableContainerView = itemView.FindViewById(underSwipeContainerViewId);
        }

        public int AfterSwipeReaction { get; set; }
        public float MaxDownSwipeAmount { get; set; }
        public float MaxLeftSwipeAmount { get; set; }
        public float MaxRightSwipeAmount { get; set; }
        public float MaxUpSwipeAmount { get; set; }
        public bool ProportionalSwipeAmountModeEnabled { get; set; }
        public float SwipeItemHorizontalSlideAmount { get; set; }
        public float SwipeItemVerticalSlideAmount { get; set; }
        public int SwipeResult { get; set; }
        public int SwipeStateFlags { get; set; }
        public View SwipeableContainerView { get; }

        public View UnderSwipeableContainerView { get; }

        public void OnSlideAmountUpdated(float p0, float p1, bool p2)
        { 

        }
    }
}