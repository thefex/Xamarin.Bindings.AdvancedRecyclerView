using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable.Action;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions;
using MvvmCross.AdvancedRecyclerView.Swipe.ResultActions.ItemManager;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using MvvmCross.AdvancedRecyclerView.ViewHolders;
using Sample.Core.Models;

namespace Sample.Android.Adapters.SimpleList;

public class SimpleListSwipeableTemplate : MvxSwipeableTemplate
{
    public static Action<object?>? OnDeleteItem { get; set; }

    public override int SwipeContainerViewGroupId => Resource.Id.swipe_container;
    public override int UnderSwipeContainerViewGroupId => Resource.Id.under_swipe_container;

    protected override int SwipeReactionType => RecyclerViewSwipeManager.ReactionCanSwipeLeft;

    protected override float MaxLeftSwipeAmount => -1.0f;

    public override MvxSwipeResultActionFactory SwipeResultActionFactory
        => new SimpleListSwipeResultActionFactory();

    private class SimpleListSwipeResultActionFactory : MvxSwipeResultActionFactory
    {
        public override SwipeResultAction GetSwipeLeftResultAction(IMvxSwipeResultActionItemManager itemProvider)
            => new DeleteSwipeResultAction(itemProvider);
    }

    private class DeleteSwipeResultAction : SwipeResultActionRemoveItem
    {
        private readonly IMvxSwipeResultActionItemManager _itemProvider;

        public DeleteSwipeResultAction(IMvxSwipeResultActionItemManager itemProvider)
        {
            _itemProvider = itemProvider;
        }

        protected override void OnPerformAction()
        {
            OnDeleteItem?.Invoke(_itemProvider.GetItem());
        }
    }
}
