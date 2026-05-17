using Android.Views;
using AndroidX.RecyclerView.Widget;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Utils;
using Object = Java.Lang.Object;

namespace Com.H6ah4i.Android.Widget.Advrecyclerview.Headerfooter
{
    // AbstractHeaderFooterWrapperAdapter was removed from the new AdvancedRecyclerView library.
    // This C# replacement extends BaseWrapperAdapter (the new base class) and implements
    // full header/footer delegation with correct position offsets and observer bridging.
    public abstract class AbstractHeaderFooterWrapperAdapter : BaseWrapperAdapter
    {
        private const int ViewTypeHeader = int.MinValue;
        private const int ViewTypeFooter = int.MinValue + 1;

        protected AbstractHeaderFooterWrapperAdapter(RecyclerView.Adapter wrappedAdapter)
            : base(wrappedAdapter)
        {
        }

        public abstract int HeaderItemCount { get; }
        public abstract int FooterItemCount { get; }

        public abstract void OnBindHeaderItemViewHolder(Object holder, int position);
        public abstract void OnBindFooterItemViewHolder(Object holder, int position);
        public abstract Object OnCreateHeaderItemViewHolder(ViewGroup parent, int viewType);
        public abstract Object OnCreateFooterItemViewHolder(ViewGroup parent, int viewType);

        public override int ItemCount => (WrappedAdapter?.ItemCount ?? 0) + HeaderItemCount + FooterItemCount;

        public override long GetItemId(int position)
        {
            if (position < HeaderItemCount) return ViewTypeHeader;
            int wrappedCount = WrappedAdapter?.ItemCount ?? 0;
            if (position >= HeaderItemCount + wrappedCount) return ViewTypeFooter;
            return WrappedAdapter.GetItemId(position - HeaderItemCount);
        }

        public override int GetItemViewType(int position)
        {
            if (position < HeaderItemCount) return ViewTypeHeader;
            int wrappedCount = WrappedAdapter?.ItemCount ?? 0;
            if (position >= HeaderItemCount + wrappedCount) return ViewTypeFooter;
            return WrappedAdapter.GetItemViewType(position - HeaderItemCount);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == ViewTypeHeader)
                return (RecyclerView.ViewHolder)OnCreateHeaderItemViewHolder(parent, viewType);
            if (viewType == ViewTypeFooter)
                return (RecyclerView.ViewHolder)OnCreateFooterItemViewHolder(parent, viewType);
            return WrappedAdapter.OnCreateViewHolder(parent, viewType);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (position < HeaderItemCount)
            {
                OnBindHeaderItemViewHolder(holder, position);
                return;
            }
            int wrappedCount = WrappedAdapter?.ItemCount ?? 0;
            if (position >= HeaderItemCount + wrappedCount)
            {
                OnBindFooterItemViewHolder(holder, position - HeaderItemCount - wrappedCount);
                return;
            }
            WrappedAdapter?.OnBindViewHolder(holder, position - HeaderItemCount);
        }

        // Offset wrapped adapter notifications so header positions are accounted for.
        protected override void OnHandleWrappedAdapterChanged()
            => NotifyDataSetChanged();

        protected override void OnHandleWrappedAdapterItemRangeChanged(int positionStart, int itemCount)
            => NotifyItemRangeChanged(positionStart + HeaderItemCount, itemCount);

        protected override void OnHandleWrappedAdapterItemRangeInserted(int positionStart, int itemCount)
            => NotifyItemRangeInserted(positionStart + HeaderItemCount, itemCount);

        protected override void OnHandleWrappedAdapterItemRangeRemoved(int positionStart, int itemCount)
            => NotifyItemRangeRemoved(positionStart + HeaderItemCount, itemCount);

        protected override void OnHandleWrappedAdapterRangeMoved(int fromPosition, int toPosition, int itemCount)
            => NotifyItemMoved(fromPosition + HeaderItemCount, toPosition + HeaderItemCount);
    }
}
