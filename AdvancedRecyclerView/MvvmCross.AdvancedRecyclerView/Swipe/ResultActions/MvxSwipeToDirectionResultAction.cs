using System;
using Android.Runtime;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using MvvmCross.AdvancedRecyclerView.Adapters;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions
{
    public class MvxSwipeToDirectionResultAction : SwipeResultActionMoveToSwipedDirection
    {
        private MvxAdvancedRecyclerViewAdapter _adpater;
        private readonly SwipeDirection _swipeDirection;
        private readonly int _position;
        private bool isSetPinned;

        public MvxSwipeToDirectionResultAction(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MvxSwipeToDirectionResultAction(MvxAdvancedRecyclerViewAdapter adpater, SwipeDirection swipeDirection, int position)
        {
            _adpater = adpater;
            _swipeDirection = swipeDirection;
            _position = position;
        }

        protected override void OnPerformAction()
        {
            base.OnPerformAction();

            var stateController = _adpater.SwipeItemPinnedStateController.FromSwipeDirection(_swipeDirection);

            if (!stateController.IsPinned(_position))
            {
                stateController.SetPinnedState(_position, true);
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