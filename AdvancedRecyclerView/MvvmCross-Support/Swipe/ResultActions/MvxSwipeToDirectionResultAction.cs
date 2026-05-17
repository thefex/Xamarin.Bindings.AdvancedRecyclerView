using System;
using Android.Runtime;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using MvvmCross.AdvancedRecyclerView.Adapters;
using MvvmCross.AdvancedRecyclerView.Adapters.NonExpandable;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions.ItemManager;

namespace MvvmCross.AdvancedRecyclerView.Swipe.ResultActions
{
    public class MvxSwipeToDirectionResultAction : SwipeResultActionMoveToSwipedDirection
    {
        private IMvxSwipeResultActionItemManager _itemProvider;
        private readonly SwipeDirection _swipeDirection;

        public MvxSwipeToDirectionResultAction(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MvxSwipeToDirectionResultAction(IMvxSwipeResultActionItemManager itemProvider, SwipeDirection swipeDirection)
        {
            _itemProvider = itemProvider;
            _swipeDirection = swipeDirection;
        }

        protected override void OnPerformAction()
        {
            base.OnPerformAction();

            var stateController = _itemProvider.GetAttachedPinnedStateControllerProviderWithItem().FromSwipeDirection(_swipeDirection);

            var item = _itemProvider.GetItem();
            if (!stateController.IsPinned(item))
            {
                stateController.SetPinnedState(item, true);
                _itemProvider.NotifyItemChanged();
            }
        }

        protected override void OnCleanUp()
        {
            base.OnCleanUp();
            _itemProvider = null;
        }
    }
}