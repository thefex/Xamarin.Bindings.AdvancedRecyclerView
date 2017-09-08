using System;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Support.V7.Widget;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Animator;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Decoration;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Utils;
using MvvmCross.AdvancedRecyclerView.Adapters;
using MvvmCross.AdvancedRecyclerView.Data;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;
using MvvmCross.Droid.Views;
using Sample.ViewModels;

namespace Sample
{
    [Activity(Label = "Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : MvxActivity<MainViewModel>,
         RecyclerViewExpandableItemManager.IOnGroupCollapseListener,
         RecyclerViewExpandableItemManager.IOnGroupExpandListener
    {
        private MvxExpandableItemAdapter expandableAdapter;
        private RecyclerView.Adapter wrappedAdapter;
        private RecyclerViewExpandableItemManager mRecyclerViewExpandableItemManager;
 
        public MainActivity()
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //var recyclerView = FindViewById<RecyclerView>(Resource.Id.RecyclerView);

            //mRecyclerViewExpandableItemManager = new RecyclerViewExpandableItemManager(null);

            //mRecyclerViewExpandableItemManager.DefaultGroupsExpandedState = true;

            //expandableAdapter = new MvxExpandableItemAdapter(BindingContext as IMvxAndroidBindingContext);
            //expandableAdapter.ExpandableDataConverter = new ItemGroupModelDataConverter();
            //expandableAdapter.TemplateSelector = new MvxDefaultExpandableTemplateSelector(Resource.Layout.expand_group_template, Resource.Layout.expand_child_template);

            //wrappedAdapter = mRecyclerViewExpandableItemManager.CreateWrappedAdapter(expandableAdapter);
            //GeneralItemAnimator animator = new RefactoredDefaultItemAnimator();

            //// Change animations are enabled by default since support-v7-recyclerview v22.
            //// Need to disable them when using animation indicator.
            //animator.SupportsChangeAnimations = false;

            //recyclerView.SetAdapter(wrappedAdapter);
            //recyclerView.SetItemAnimator(animator);
            //recyclerView.HasFixedSize = (false);

            //// additional decorations
            ////noinspection StatementWithEmptyBody
            if (DoesSupportViewElevation())
            {
                // Lollipop or later has native drop shadow feature. ItemShadowDecorator is not required.
            }
            else
            {
                // check advancedrecyclerview samples
             //   recyclerView.AddItemDecoration(new ItemShadowDecorator((NinePatchDrawable)ContextCompat.GetDrawable(this, Resource.Drawable.material_shadow_z1)));
            }
            //recyclerView.AddItemDecoration(new SimpleListDividerDecorator(ContextCompat.GetDrawable(this, Resource.Drawable.list_divider_h), true));
            //recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            //mRecyclerViewExpandableItemManager.AttachRecyclerView(recyclerView);

            //var bindingSet = this.CreateBindingSet<MainActivity, MainViewModel>();

            //bindingSet.Bind(expandableAdapter)
            //    .For(x => x.ItemsSource)
            //    .To(x => x.Items);

            //bindingSet.Apply();
        }

        protected override void OnDestroy()
        {
            //mRecyclerViewExpandableItemManager?.Release();
            //if (wrappedAdapter != null)
                //WrapperAdapterUtils.ReleaseAll(wrappedAdapter);
            base.OnDestroy();    
        }

        private bool DoesSupportViewElevation()
        {
            return (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop);
        }

        public void OnGroupCollapse(int p0, bool p1)
        {
             
        }

        public void OnGroupExpand(int p0, bool p1)
        {
           
        }
    }
}

