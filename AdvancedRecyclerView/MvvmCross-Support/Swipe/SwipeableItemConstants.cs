using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;

namespace Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable
{
    // Shim: SwipeableItemConstants was removed from the new library bindings.
    // Constants are now nested inside RecyclerViewSwipeManager.
    public static class SwipeableItemConstants
    {
        public const int DrawableSwipeNeutralBackground = RecyclerViewSwipeManager.DrawableSwipeNeutralBackground;
        public const int DrawableSwipeLeftBackground = RecyclerViewSwipeManager.DrawableSwipeLeftBackground;
        public const int DrawableSwipeRightBackground = RecyclerViewSwipeManager.DrawableSwipeRightBackground;
        // Up/Down backgrounds removed from new library; use 0 as fallback.
        public const int DrawableSwipeUpBackground = 4;
        public const int DrawableSwipeDownBackground = 3;

        // ReactionCanNotSwipeAny = 0 (same as ReactionCanNotSwipeBoth)
        public const int ReactionCanNotSwipeAny = RecyclerViewSwipeManager.ReactionCanNotSwipeBoth;

        public const int ResultSwipedLeft = RecyclerViewSwipeManager.ResultSwipedLeft;
        public const int ResultSwipedRight = RecyclerViewSwipeManager.ResultSwipedRight;
        // Up/Down swipe results removed from new library; use distinct sentinel values.
        public const int ResultSwipedUp = 4;
        public const int ResultSwipedDown = 5;

        public const int StateFlagIsActive = RecyclerViewSwipeManager.StateFlagIsActive;
        public const int StateFlagIsUpdated = RecyclerViewSwipeManager.StateFlagIsUpdated;
        public const int StateFlagSwiping = RecyclerViewSwipeManager.StateFlagSwiping;
    }
}
