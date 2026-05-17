using Android.Views;
using AndroidX.RecyclerView.Widget;
using Object = Java.Lang.Object;

namespace Com.H6ah4i.Android.Widget.Advrecyclerview.Headerfooter
{
    // Stub: AbstractHeaderFooterWrapperAdapter was removed from the new library.
    // This C# stub provides the same API surface so the code compiles.
    // Header/footer functionality will not work at runtime with the new library.
    public abstract class AbstractHeaderFooterWrapperAdapter : RecyclerView.Adapter
    {
        protected RecyclerView.Adapter WrappedAdapter { get; private set; }

        protected void SetAdapter(RecyclerView.Adapter adapter)
        {
            WrappedAdapter = adapter;
        }

        public abstract int HeaderItemCount { get; }
        public abstract int FooterItemCount { get; }

        public abstract void OnBindHeaderItemViewHolder(Object p0, int p1);
        public abstract void OnBindFooterItemViewHolder(Object p0, int p1);
        public abstract Object OnCreateHeaderItemViewHolder(ViewGroup p0, int p1);
        public abstract Object OnCreateFooterItemViewHolder(ViewGroup p0, int p1);

        public override int ItemCount => (WrappedAdapter?.ItemCount ?? 0) + HeaderItemCount + FooterItemCount;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) { }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            => throw new System.NotImplementedException("AbstractHeaderFooterWrapperAdapter is not supported by the new library.");
    }
}
