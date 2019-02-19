using Android.Views;
using RecordGuard.ListSample.Android.Extensions;

namespace RecordGuard.ListSample.Android.ViewControllers
{
    public class EmptyListAnimationController
    {
        private readonly View _viewToShowWhenEmpty;
        private readonly View _viewToShowWhenHasItems;

        public EmptyListAnimationController(View viewToShowWhenEmpty, View viewToShowWhenHasItems)
        {
            _viewToShowWhenEmpty = viewToShowWhenEmpty;
            _viewToShowWhenHasItems = viewToShowWhenHasItems;
        }

        private bool hasAnyItems;
        private bool hasAnyItemsBeenSetAtLeastOnce = false;
        public bool HasAnyItems
        {
            get => hasAnyItems;
            set
            {
                if (hasAnyItems != value || !hasAnyItemsBeenSetAtLeastOnce)
                {
                    hasAnyItemsBeenSetAtLeastOnce = true;
                    hasAnyItems = value;
                    
                    if (hasAnyItems)
                        ShowListView();
                    else
                        ShowEmptyView();
                }
            }
        }

        private void ShowEmptyView()
        {
            _viewToShowWhenEmpty.FadeIn();
            _viewToShowWhenHasItems.FadeOut(ViewStates.Invisible);
        }

        private void ShowListView()
        {
            _viewToShowWhenHasItems.FadeIn();
            _viewToShowWhenEmpty.FadeOut(ViewStates.Invisible);
        }
    }
}