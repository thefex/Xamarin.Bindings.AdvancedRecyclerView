using System;
using Android.OS;
using Android.Support.V7.Widget;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable;
using MvvmCross.AdvancedRecyclerView.Extensions;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace MvvmCross.AdvancedRecyclerView.Adapters.Expandable
{
    public class MvxAdvancedRecyclerViewExpandableAdapterController : MvxAdvancedRecyclerViewAdapterController
    {
        RecyclerViewExpandableItemManager expandableItemManager;
        RecyclerView.Adapter wrappedAdapter;
        IParcelable expandCollapseSavedState;

        private string ExpandManagerParcelableKey = "ExpandManagerStateParcelKey";

        public MvxAdvancedRecyclerViewExpandableAdapterController(Android.Content.Context context, Android.Util.IAttributeSet attrs, RecyclerView recyclerView, IMvxAndroidBindingContext bindingContext)
         : base(context, attrs, recyclerView, bindingContext)
        {
          
        }

        protected override RecyclerView.Adapter BuildWrappedAdapter(IMvxTemplateSelector templateSelector)
        {
            bool isGroupingSupported = MvxAdvancedRecyclerViewAttributeExtensions.IsGroupingSupported(Context, Attrs);

            if (!isGroupingSupported)
                throw new InvalidOperationException($"You are using {nameof(MvxAdvancedExpandableRecyclerView)} without using grouping attributes. Check documentation.");
                
            expandableItemManager = new RecyclerViewExpandableItemManager(expandCollapseSavedState);
            var expandableAdapter = new MvxExpandableItemAdapter(BindingContext as IMvxAndroidBindingContext);

            expandableAdapter.TemplateSelector = templateSelector;
            expandableAdapter.GroupExpandController = MvxAdvancedRecyclerViewAttributeExtensions.BuildGroupExpandController(Context, Attrs);
            expandableItemManager.DefaultGroupsExpandedState = expandableAdapter.GroupExpandController.AreGroupsExpandedByDefault;
            expandableAdapter.GroupExpandController.ExpandableItemManager = expandableItemManager;

            AdvancedRecyclerViewAdapter = expandableAdapter;
            var groupedDataConverter = MvxAdvancedRecyclerViewAttributeExtensions.BuildMvxGroupedDataConverter(Context, Attrs);

            expandableAdapter.ExpandableDataConverter = groupedDataConverter;
            wrappedAdapter = expandableItemManager.CreateWrappedAdapter(expandableAdapter);

            return wrappedAdapter;
        }
        
        public override void AttachRecyclerView()
        {
            expandableItemManager?.AttachRecyclerView(RecyclerView);
        }

        public override void Dispose()
        {
            expandableItemManager?.Release();
            expandableItemManager = null;
        }

        public override void RestoreFromBundle(Bundle bundle)
        {
            base.RestoreFromBundle(bundle);
            
            if (bundle.ContainsKey(ExpandManagerParcelableKey))
                expandCollapseSavedState = (IParcelable)bundle.GetParcelable(ExpandManagerParcelableKey);
		}

        public override void SaveToBundle(Bundle bundle)
        {
            base.SaveToBundle(bundle);
            
            if (expandableItemManager != null)
			{
                bundle.PutParcelable(
			        ExpandManagerParcelableKey,
                    expandableItemManager.GetSavedState());
			}
		}
    }
}
