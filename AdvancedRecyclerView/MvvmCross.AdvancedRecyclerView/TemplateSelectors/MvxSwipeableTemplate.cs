using System;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using MvvmCross.AdvancedRecyclerView.Data.EventArguments;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions;
using MvvmCross.AdvancedRecyclerView.Swipe.State;
using MvvmCross.AdvancedRecyclerView.ViewHolders;

namespace MvvmCross.AdvancedRecyclerView.TemplateSelectors
{
    public abstract class MvxSwipeableTemplate
    {
        public abstract int SwipeContainerViewGroupId { get; }

        public abstract int UnderSwipeContainerViewGroupId { get; }

        protected abstract int SwipeReactionType { get; }

        public virtual int GetSwipeReactionType(object dataContext, MvxAdvancedRecyclerViewHolder holder) => SwipeReactionType;

        /// <summary>
        /// Value from range [-1.0, 0.0]
        /// </summary>
        protected virtual float MaxLeftSwipeAmount { get; } = 0;

        /// <summary>
        /// You can override this method and change value of Left Swipe Amount (or completely disable) based on ViewHolder/Data model.
        /// </summary>
        /// <returns></returns>
        public virtual float GetMaxLeftSwipeAmount(object dataContext, MvxAdvancedRecyclerViewHolder viewHolder)
            => MaxLeftSwipeAmount;
        
        /// <summary>
        /// Value from range [0.0, 1.0]
        /// </summary>
        protected virtual float MaxRightSwipeAmount { get; } = 0;
        
        /// <summary>
        /// You can override this method and change value of Right Swipe Amount (or completely disable) based on ViewHolder/Data model.
        /// </summary>
        /// <returns></returns>
        public virtual float GetMaxRightSwipeAmount(object dataContext, MvxAdvancedRecyclerViewHolder viewHolder)
            => MaxRightSwipeAmount;
        
        /// <summary>
        /// Value from range [0.0, 1.0]
        /// </summary>
        protected virtual float MaxDownSwipeAmount { get; } = 0;
        
        /// <summary>
        /// You can override this method and change value of Down Swipe Amount (or completely disable) based on ViewHolder/Data model.
        /// </summary>
        /// <returns></returns>
        public virtual float GetMaxDownSwipeAmount(object dataContext, MvxAdvancedRecyclerViewHolder viewHolder)
            => MaxDownSwipeAmount;
        
        /// <summary>
        /// Value from range [-1.0, 0.0]
        /// </summary>
        protected virtual float MaxUpSwipeAmount { get; } = 0;
        
        /// <summary>
        /// You can override this method and change value of Up Swipe Amount (or completely disable) based on ViewHolder/Data model.
        /// </summary>
        /// <returns></returns>
        public virtual float GetMaxUpSwipeAmount(object dataContext, MvxAdvancedRecyclerViewHolder viewHolder)
            => MaxUpSwipeAmount;
        
        public void SetupSlideAmount(MvxAdvancedRecyclerViewHolder holder, SwipeItemPinnedStateControllerProvider swipeItemPinnedStateController)
        {
            if (swipeItemPinnedStateController.ForLeftSwipe().IsPinned(holder.DataContext))
                holder.SwipeItemHorizontalSlideAmount = MaxLeftSwipeAmount;
            else if (swipeItemPinnedStateController.ForRightSwipe().IsPinned(holder.DataContext))
                holder.SwipeItemHorizontalSlideAmount = MaxRightSwipeAmount;

            if (swipeItemPinnedStateController.ForTopSwipe().IsPinned(holder.DataContext))
                holder.SwipeItemVerticalSlideAmount = MaxUpSwipeAmount;
            else if (swipeItemPinnedStateController.ForBottomSwipe().IsPinned(holder.DataContext))
                holder.SwipeItemVerticalSlideAmount = MaxDownSwipeAmount;
        }
        
        public virtual int UnderSwipeBackgroundResourceIdWhenSwipeActive { get; } = -1;

        public virtual int UnderSwipeBackgroundResourceIdWhenSwiping { get; } = -1;

        public virtual int UnderSwipeBackgroundResourceIdWhenNormalState { get; } = -1;
        
        public void SetupUnderSwipeBackground(MvxAdvancedRecyclerViewHolder swipeHolder)
        {
            var swipeState = swipeHolder.SwipeStateFlags;

            if ((swipeState & SwipeableItemConstants.StateFlagIsUpdated & 0) == 0)
            {
                int backgroundResourceId = -1;
                if ((swipeState & SwipeableItemConstants.StateFlagIsActive) != 0 && UnderSwipeBackgroundResourceIdWhenSwipeActive != -1)
                    backgroundResourceId = UnderSwipeBackgroundResourceIdWhenSwipeActive;
                else if ((swipeState & SwipeableItemConstants.StateFlagSwiping) != 0 && UnderSwipeBackgroundResourceIdWhenSwiping != -1)
                    backgroundResourceId = UnderSwipeBackgroundResourceIdWhenSwiping;
                else if (UnderSwipeBackgroundResourceIdWhenNormalState != -1)
                    backgroundResourceId = UnderSwipeBackgroundResourceIdWhenNormalState;
                
                if (backgroundResourceId != -1)
                    swipeHolder.UnderSwipeableContainerView.SetBackgroundResource(backgroundResourceId);
            }
        }

        public virtual int ItemViewSwipeUpBackgroundResourceId { get; } = -1;

        public virtual int ItemViewSwipeDownBackgroundResourceId { get; } = -1;

        public virtual int ItemViewSwipeLeftBackgroundResourceId { get; } = -1;

        public virtual int ItemViewSwipeRightBackgroundResourceId { get; } = -1;

        public virtual int ItemViewSwipeNeutralBackgroundResourceId { get; } = -1;

        public void OnSwipeBackgroundSet(MvxSwipeBackgroundSetEventArgs args)
        {
            int backgroundResourceId = -1;
            switch (args.Type)
            {
                case SwipeableItemConstants.DrawableSwipeUpBackground:
                    backgroundResourceId = ItemViewSwipeUpBackgroundResourceId;
                    break;
                case SwipeableItemConstants.DrawableSwipeDownBackground:
                    backgroundResourceId = ItemViewSwipeDownBackgroundResourceId;
                    break;
                case SwipeableItemConstants.DrawableSwipeLeftBackground:
                    backgroundResourceId = ItemViewSwipeLeftBackgroundResourceId;
                    break;
                case SwipeableItemConstants.DrawableSwipeRightBackground:
                    backgroundResourceId = ItemViewSwipeRightBackgroundResourceId;
                    break;
                case SwipeableItemConstants.DrawableSwipeNeutralBackground:
                    backgroundResourceId = ItemViewSwipeNeutralBackgroundResourceId;
                    break;
            }
            
            if (backgroundResourceId != -1)
                args.ViewHolder.ItemView.SetBackgroundResource(backgroundResourceId);
        }
        
        public virtual MvxSwipeResultActionFactory SwipeResultActionFactory { get; } = new MvxSwipeResultActionFactory();
    }
}