using System;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using MvvmCross.AdvancedRecyclerView.ViewHolders;

namespace MvvmCross.AdvancedRecyclerView.TemplateSelectors
{
    public class DefaultSwipeableTemplate : MvxSwipeableTemplate
    {
        public DefaultSwipeableTemplate()
        {
        }

        public override int SwipeContainerViewGroupId => -1;

        public override int UnderSwipeContainerViewGroupId => -1;

        protected override int SwipeReactionType => SwipeableItemConstants.ReactionCanNotSwipeAny;
    }
}
