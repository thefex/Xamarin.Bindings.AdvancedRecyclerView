using System;

namespace MvvmCross.AdvancedRecyclerView.Swipe.State
{
    public class SwipeItemPinnedStateControllerProvider
    {
        private readonly SwipeItemPinnedStateController _bottomSwipeStateController;
        private readonly SwipeItemPinnedStateController _leftSwipeStateController;
        private readonly SwipeItemPinnedStateController _rightSwipeStateController;
        private readonly SwipeItemPinnedStateController _topSwipeStateController;

        public SwipeItemPinnedStateControllerProvider()
        {
            _leftSwipeStateController = new SwipeItemPinnedStateController();
            _rightSwipeStateController = new SwipeItemPinnedStateController();
            _topSwipeStateController = new SwipeItemPinnedStateController();
            _bottomSwipeStateController = new SwipeItemPinnedStateController();
        }

        public SwipeItemPinnedStateController ForLeftSwipe() => _leftSwipeStateController;

        public SwipeItemPinnedStateController ForRightSwipe() => _rightSwipeStateController;

        public SwipeItemPinnedStateController ForTopSwipe() => _topSwipeStateController;

        public SwipeItemPinnedStateController ForBottomSwipe() => _bottomSwipeStateController;

        public SwipeItemPinnedStateController FromSwipeDirection(SwipeDirection swipeDirection)
        {
            switch (swipeDirection)
            {
                case SwipeDirection.FromBottom:
                    return ForBottomSwipe();
                case SwipeDirection.FromTop:
                    return ForTopSwipe();
                case SwipeDirection.FromLeft:
                    return ForLeftSwipe();
                case SwipeDirection.FromRight:
                    return ForRightSwipe();
            }

            throw new InvalidOperationException($"{swipeDirection} swipe direction is not implemented.");
        }

        public bool IsPinnedForAnyState(int atPosition)
        {
            return ForTopSwipe().IsPinned(atPosition) ||
                   ForRightSwipe().IsPinned(atPosition) ||
                   ForLeftSwipe().IsPinned(atPosition) ||
                   ForBottomSwipe().IsPinned(atPosition);
        }

        public void SetPinnedForAllStates(int atPosition, bool isPinned)
        {
            ForTopSwipe().SetPinnedState(atPosition, isPinned);
            ForBottomSwipe().SetPinnedState(atPosition, isPinned);
            ForLeftSwipe().SetPinnedState(atPosition, isPinned);
            ForRightSwipe().SetPinnedState(atPosition, isPinned);
        }

        public void ResetState()
        {
            _leftSwipeStateController.ResetState();
            _rightSwipeStateController.ResetState();
            _bottomSwipeStateController.ResetState();
            _topSwipeStateController.ResetState();
        }
    }
}