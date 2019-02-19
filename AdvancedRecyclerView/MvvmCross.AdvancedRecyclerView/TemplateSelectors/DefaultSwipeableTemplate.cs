using System;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;

namespace MvvmCross.AdvancedRecyclerView.TemplateSelectors
{
    public class DefaultSwipeableTemplate : MvxSwipeableTemplate
    {
        public DefaultSwipeableTemplate()
        {
        }

        public override int SwipeContainerViewGroupId => -1;

        public override int UnderSwipeContainerViewGroupId => -1;

        public override int SwipeReactionType => SwipeableItemConstants.ReactionCanNotSwipeAny;
    }
}
