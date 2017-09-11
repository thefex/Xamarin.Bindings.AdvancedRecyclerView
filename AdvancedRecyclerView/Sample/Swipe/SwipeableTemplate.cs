using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;

namespace Sample.Swipe
{
    public class SwipeableTemplate : IMvxSwipeableTemplate
    {
        public int SwipeContainerViewGroupId => Resource.Id.container;

        public int UnderSwipeContainerViewGroupId => Resource.Id.underSwipe;

        public int SwipeReactionType => SwipeableItemConstants.ReactionCanSwipeBothH;
    }
}