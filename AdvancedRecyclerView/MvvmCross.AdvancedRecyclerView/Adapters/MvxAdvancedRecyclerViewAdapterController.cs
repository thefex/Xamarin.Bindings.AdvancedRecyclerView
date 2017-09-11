using System;
using Android.Support.V7.Widget;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Animator;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Touchguard;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Utils;
using MvvmCross.AdvancedRecyclerView.Extensions;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace MvvmCross.AdvancedRecyclerView.Adapters
{
    public class MvxAdvancedRecyclerViewAdapterController : IDisposable
    {
        RecyclerViewExpandableItemManager expandableItemManager;
        RecyclerView.Adapter wrappedAdapter;
        private RecyclerViewTouchActionGuardManager mRecyclerViewTouchActionGuardManager;
        private RecyclerViewSwipeManager mRecyclerViewSwipeManager;

        public MvxAdvancedRecyclerViewAdapterController()
        {
        }


        public RecyclerView.Adapter BuildAdapter(Android.Content.Context context, Android.Util.IAttributeSet attrs, RecyclerView recyclerView, IMvxAndroidBindingContext bindingContext)
        {
			bool isGroupingSupported = MvxAdvancedRecyclerViewAttributeExtensions.IsGroupingSupported(context, attrs);

			if (isGroupingSupported)
				return BuildExpandableAdapter(context, attrs, recyclerView, bindingContext);

			return BuildAdvancedRecyclerViewAdapter(context, attrs, recyclerView, bindingContext);
		}

        public void AttachRecyclerView(RecyclerView recyclerView)
        {
			mRecyclerViewTouchActionGuardManager?.AttachRecyclerView(recyclerView);
			mRecyclerViewSwipeManager?.AttachRecyclerView(recyclerView);
			expandableItemManager?.AttachRecyclerView(recyclerView);
		}

        private RecyclerView.Adapter BuildAdvancedRecyclerViewAdapter(Android.Content.Context context, Android.Util.IAttributeSet attrs, RecyclerView recyclerView, IMvxAndroidBindingContext bindingContext)
        {
			var advancedRecyclerViewAdapter = new MvxAdvancedRecyclerViewAdapter(bindingContext);
            RecyclerView.Adapter adapter = advancedRecyclerViewAdapter;
			var templateSelector = MvxAdvancedRecyclerViewAttributeExtensions.BuildItemTemplateSelector(context, attrs);
            var itemUniqueIdProvider = MvxAdvancedRecyclerViewAttributeExtensions.BuildUniqueItemIdProvider(context, attrs);
            advancedRecyclerViewAdapter.UniqueIdProvider = itemUniqueIdProvider;
            advancedRecyclerViewAdapter.ItemTemplateSelector = templateSelector;

			AdvancedRecyclerViewAdapter = advancedRecyclerViewAdapter;

            bool isSwipeEnabled = MvxAdvancedRecyclerViewAttributeExtensions.IsSwipeSupported(context, attrs);

            if (isSwipeEnabled)
            {
                var swipeableTemplate = MvxAdvancedRecyclerViewAttributeExtensions.BuildSwipeableTemplate(context, attrs);
                advancedRecyclerViewAdapter.SwipeableTemplate = swipeableTemplate;

                mRecyclerViewTouchActionGuardManager = new RecyclerViewTouchActionGuardManager();
                mRecyclerViewTouchActionGuardManager.SetInterceptVerticalScrollingWhileAnimationRunning(true);
                mRecyclerViewTouchActionGuardManager.Enabled = true;

                mRecyclerViewSwipeManager = new RecyclerViewSwipeManager();

                wrappedAdapter = mRecyclerViewSwipeManager.CreateWrappedAdapter(advancedRecyclerViewAdapter);
                return wrappedAdapter;
            }

            return new MvxHeaderFooterWrapperAdapter(advancedRecyclerViewAdapter)
            {
                HeaderFooterDetails = BuildHeaderFooterDetails(templateSelector)
            };
        }

        private RecyclerView.Adapter BuildExpandableAdapter(Android.Content.Context context, Android.Util.IAttributeSet attrs, RecyclerView recyclerView, IMvxAndroidBindingContext bindingContext)
        {
            expandableItemManager = new RecyclerViewExpandableItemManager(null);
            expandableItemManager.DefaultGroupsExpandedState = true;

            var expandableAdapter = new MvxExpandableItemAdapter(bindingContext as IMvxAndroidBindingContext);
            AdvancedRecyclerViewAdapter = expandableAdapter;
            var groupedDataConverter = MvxAdvancedRecyclerViewAttributeExtensions.BuildMvxGroupedDataConverter(context, attrs);

            expandableAdapter.ExpandableDataConverter = groupedDataConverter;

            var templateSelector = MvxAdvancedRecyclerViewAttributeExtensions.BuildItemTemplateSelector(context, attrs) as MvxExpandableTemplateSelector;
            expandableAdapter.TemplateSelector = templateSelector ?? throw new InvalidOperationException("You can't use Expandable adapter without MvxExpandableTemplateSelector.");
            expandableAdapter.GroupExpandController = MvxAdvancedRecyclerViewAttributeExtensions.BuildGroupExpandController(context, attrs);

            wrappedAdapter = expandableItemManager.CreateWrappedAdapter(expandableAdapter);

            return new MvxHeaderFooterWrapperAdapter(wrappedAdapter, bindingContext)
            {
                HeaderFooterDetails = BuildHeaderFooterDetails(templateSelector)
            };
        }

        private Data.MvxHeaderFooterDetails BuildHeaderFooterDetails(IMvxTemplateSelector templateSelector)
        {
            var headerFooterDetails = new Data.MvxHeaderFooterDetails();
            var headerTemplate = templateSelector as IMvxHeaderTemplate;
            var footerTemplate = templateSelector as IMvxFooterTemplate;

            if (headerTemplate != null)
                headerFooterDetails.HeaderLayoutId = headerTemplate.HeaderLayoutId;
            if (footerTemplate != null)
                headerFooterDetails.FooterLayoutId = footerTemplate.FooterLayoutId;

            return headerFooterDetails;
        }

        public void Dispose()
        {
            expandableItemManager?.Release();
            mRecyclerViewTouchActionGuardManager?.Release();
            mRecyclerViewSwipeManager?.Release();
            expandableItemManager = null;
            mRecyclerViewTouchActionGuardManager = null;
            mRecyclerViewSwipeManager = null;
            if (wrappedAdapter != null)
                WrapperAdapterUtils.ReleaseAll(wrappedAdapter); 
            wrappedAdapter = null;
        }

        public IMvxAdvancedRecyclerViewAdapter AdvancedRecyclerViewAdapter { get; private set; }
    }
}
