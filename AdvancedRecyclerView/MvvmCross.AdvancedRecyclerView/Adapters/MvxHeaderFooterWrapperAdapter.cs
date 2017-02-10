using Android.Views;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Headerfooter;
using MvvmCross.AdvancedRecyclerView.TemplateSelectors;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Object = Java.Lang.Object;

namespace MvvmCross.AdvancedRecyclerView.Adapters
{
    public class MvxHeaderFooterWrapperAdapter : AbstractHeaderFooterWrapperAdapter
    {
        public override int FooterItemCount { get; } = 1;
        public override int HeaderItemCount { get; } = 1;

        public MvxExpandableTemplateSelector HeaderFooterTemplateSelector { get; set; }

        public MvxHeaderFooterWrapperAdapter() : this (MvxAndroidBindingContextHelpers.Current())
        {
            
        }

        public MvxHeaderFooterWrapperAdapter(IMvxAndroidBindingContext bindingContext)
        {
            BindingContext = bindingContext;
        }

        protected IMvxAndroidBindingContext BindingContext { get; }


        public override void OnBindFooterItemViewHolder(Object p0, int p1)
        {
            (p0 as IMvxRecyclerViewHolder).DataContext = BindingContext.DataContext;
        }

        public override void OnBindHeaderItemViewHolder(Object p0, int p1)
        {
            (p0 as IMvxRecyclerViewHolder).DataContext = BindingContext.DataContext;
        }

        public override Object OnCreateFooterItemViewHolder(ViewGroup p0, int p1)
        {
            var itemBindingContext = new MvxAndroidBindingContext(p0.Context, BindingContext.LayoutInflaterHolder);

            var viewHolder =
                new MvxRecyclerViewHolder(
                    InflateViewForHolder(HeaderFooterTemplateSelector.FooterLayoutId, p0, p1, itemBindingContext),
                    itemBindingContext)
                {
                    Click = FooterClickCommand,
                    LongClick = FooterLongClickCommand
                };

            return viewHolder;
        }

        public override Object OnCreateHeaderItemViewHolder(ViewGroup p0, int p1)
        {
            var itemBindingContext = new MvxAndroidBindingContext(p0.Context, BindingContext.LayoutInflaterHolder);

            var viewHolder =
                new MvxRecyclerViewHolder(
                    InflateViewForHolder(HeaderFooterTemplateSelector.HeaderLayoutId, p0, p1, itemBindingContext),
                    itemBindingContext)
                {
                    Click = HeaderClickCommand,
                    LongClick = HeaderLongClickCommand
                };

            return viewHolder;
        }

        private View InflateViewForHolder(int headerLayoutId, ViewGroup p0, int p1, MvxAndroidBindingContext itemBindingContext)
            => itemBindingContext.BindingInflate(headerLayoutId, p0, false);

        public MvxCommand HeaderClickCommand { get; set; }
        public MvxCommand HeaderLongClickCommand { get; set; }

        public MvxCommand FooterClickCommand { get; set; }
        public MvxCommand FooterLongClickCommand { get; set; }
    }
}