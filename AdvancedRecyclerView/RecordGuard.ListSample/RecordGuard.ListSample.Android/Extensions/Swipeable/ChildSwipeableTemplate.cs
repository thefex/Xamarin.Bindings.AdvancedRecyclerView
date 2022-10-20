using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;

namespace RecordGuard.ListSample.Android.Extensions.Swipeable
{
    public class ChildSwipeableTemplate : MvxSwipeableTemplate
    {
        public override int SwipeContainerViewGroupId => Resource.Id.container;
        public override int UnderSwipeContainerViewGroupId => Resource.Id.underSwipe;

        protected override int SwipeReactionType => SwipeableItemConstants.ReactionCanSwipeBothH;

        protected override float MaxLeftSwipeAmount => -1f;
  
        public override MvxSwipeResultActionFactory SwipeResultActionFactory => new SwipeResultActionFactory();
    }
}