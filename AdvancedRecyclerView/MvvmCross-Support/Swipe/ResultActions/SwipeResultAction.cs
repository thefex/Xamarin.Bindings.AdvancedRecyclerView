using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;

namespace Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action
{
    // Pure C# shim: the new library removed SwipeResultAction Java classes.
    // OnSwipeItem now returns int (AfterSwipeReaction* constants).
    public abstract class SwipeResultAction
    {
        internal int _resultCode = RecyclerViewSwipeManager.AfterSwipeReactionDefault;

        protected abstract void OnPerformAction();
        protected virtual void OnCleanUp() { }

        internal void PerformAction() => OnPerformAction();
        internal void CleanUp() => OnCleanUp();
    }

    public class SwipeResultActionDoNothing : SwipeResultAction
    {
        public SwipeResultActionDoNothing()
        {
            _resultCode = RecyclerViewSwipeManager.AfterSwipeReactionDefault;
        }

        protected override void OnPerformAction() { }
    }

    public abstract class SwipeResultActionDefault : SwipeResultAction
    {
        protected SwipeResultActionDefault()
        {
            _resultCode = RecyclerViewSwipeManager.AfterSwipeReactionDefault;
        }
    }

    public abstract class SwipeResultActionMoveToSwipedDirection : SwipeResultAction
    {
        protected SwipeResultActionMoveToSwipedDirection()
        {
            _resultCode = RecyclerViewSwipeManager.AfterSwipeReactionMoveToSwipedDirection;
        }
    }

    public abstract class SwipeResultActionRemoveItem : SwipeResultAction
    {
        protected SwipeResultActionRemoveItem()
        {
            _resultCode = RecyclerViewSwipeManager.AfterSwipeReactionRemoveItem;
        }
    }
}
