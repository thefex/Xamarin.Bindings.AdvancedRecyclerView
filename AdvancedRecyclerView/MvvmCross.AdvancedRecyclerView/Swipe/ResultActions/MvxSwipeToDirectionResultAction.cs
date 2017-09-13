using System;
using Android.Runtime;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using MvvmCross.AdvancedRecyclerView.Adapters;
using MvvmCross.AdvancedRecyclerView.Adapters.NonExpandable;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions
{
    public class MvxSwipeToDirectionResultAction : SwipeResultActionMoveToSwipedDirection
    {
        private MvxNonExpandableAdapter _adpater;
        private readonly SwipeDirection _swipeDirection;
        private readonly int _position;
        private bool isSetPinned;

        public MvxSwipeToDirectionResultAction(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MvxSwipeToDirectionResultAction(MvxNonExpandableAdapter adpater, SwipeDirection swipeDirection, int position)
        {
            _adpater = adpater;
            _swipeDirection = swipeDirection;
            _position = position;
        }

        protected override void OnPerformAction()
        {
            base.OnPerformAction();

            var stateController = _adpater.SwipeItemPinnedStateController.FromSwipeDirection(_swipeDirection);

            var item = _adpater.GetItem(_position);
            if (!stateController.IsPinned(item))
            {
                stateController.SetPinnedState(item, true);
                isSetPinned = true;
                _adpater.NotifyItemChanged(_position);
            }
        }

        protected override void OnSlideAnimationEnd()
        {
            base.OnSlideAnimationEnd();
        }

        protected override void OnCleanUp()
        {
            base.OnCleanUp();
            _adpater = null;
        }
    }
}