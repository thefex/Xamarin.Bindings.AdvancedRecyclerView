using System;
using Android.Runtime;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using MvvmCross.AdvancedRecyclerView.Adapters;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions
{
    public class MvxSwipeUnpinResultAction : SwipeResultActionDefault
    {
        private MvxAdvancedRecyclerViewAdapter _adpater;
        private readonly int _position;

        public MvxSwipeUnpinResultAction(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MvxSwipeUnpinResultAction(MvxAdvancedRecyclerViewAdapter adpater, int position)
        {
            _adpater = adpater;
            _position = position;
        }

        protected override void OnPerformAction()
        {
            base.OnPerformAction();

            if (_adpater.SwipeItemPinnedStateController.IsPinnedForAnyState(_position))
            {
                _adpater.SwipeItemPinnedStateController.SetPinnedForAllStates(_position, false);
                _adpater.NotifyItemChanged(_position);
            }
        }

        protected override void OnCleanUp()
        {
            base.OnCleanUp();
            _adpater = null;
        }
    }
}