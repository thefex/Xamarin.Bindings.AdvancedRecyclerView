using System;
using Android.Support.V7.Widget;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Utils;
using MvvmCross.AdvancedRecyclerView.Extensions;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MvvmCross.AdvancedRecyclerView.Adapters
{
    public class MvxAdvancedRecyclerViewAdapterController : IDisposable
    {
        RecyclerViewExpandableItemManager expandableItemManager;
        RecyclerView.Adapter wrappedAdapter;

        public MvxAdvancedRecyclerViewAdapterController()
        {
        }


        public RecyclerView.Adapter BuildAdapter(Android.Content.Context context, Android.Util.IAttributeSet attrs, RecyclerView recyclerView, IMvxAndroidBindingContext bindingContext)
        {
			bool isGroupingSupported = MvxAdvancedRecyclerViewAttributeExtensions.IsGroupingSupported(context, attrs);

            if (isGroupingSupported)
                return BuildExpandableAdapter(context, attrs, recyclerView, bindingContext);

            var advancedRecyclerViewAdapter = new MvxAdvancedRecyclerViewAdapter(bindingContext);
            AdvancedRecyclerViewAdapter = advancedRecyclerViewAdapter;
            return advancedRecyclerViewAdapter;
		}

        private RecyclerView.Adapter BuildExpandableAdapter(Android.Content.Context context, Android.Util.IAttributeSet attrs, RecyclerView recyclerView, IMvxAndroidBindingContext bindingContext)
        {
			expandableItemManager = new RecyclerViewExpandableItemManager(null);
			expandableItemManager.DefaultGroupsExpandedState = true;

			var expandableAdapter = new MvxExpandableItemAdapter(bindingContext as IMvxAndroidBindingContext);
            var groupedDataConverter = MvxAdvancedRecyclerViewAttributeExtensions.BuildMvxGroupedDataConverter(context, attrs);

            expandableAdapter.ExpandableDataConverter = groupedDataConverter;

            var templateSelector = MvxAdvancedRecyclerViewAttributeExtensions.BuildItemTemplateSelector(context, attrs) as MvxExpandableTemplateSelector;
            expandableAdapter.TemplateSelector = templateSelector ?? throw new InvalidOperationException("You can't use Expandable adapter without MvxExpandableTemplateSelector.");
            expandableAdapter.GroupExpandController = MvxAdvancedRecyclerViewAttributeExtensions.BuildGroupExpandController(context, attrs);

			wrappedAdapter = expandableItemManager.CreateWrappedAdapter(expandableAdapter);
			expandableItemManager.AttachRecyclerView(recyclerView);
            AdvancedRecyclerViewAdapter = expandableAdapter;

            return wrappedAdapter;
        }

        public void Dispose()
        {
            expandableItemManager?.Release();
            expandableItemManager = null;
            if (wrappedAdapter != null)
                WrapperAdapterUtils.ReleaseAll(wrappedAdapter); 
            wrappedAdapter = null;
        }

        public IMvxAdvancedRecyclerViewAdapter AdvancedRecyclerViewAdapter { get; private set; }
    }
}
