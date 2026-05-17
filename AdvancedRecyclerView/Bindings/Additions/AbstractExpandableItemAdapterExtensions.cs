using Android.Runtime;
using Android.Views;

namespace Com.H6ah4i.Android.Widget.Advrecyclerview.Utils
{
    // AbstractExpandableItemAdapter is abstract in Java and intentionally leaves the
    // ExpandableItemAdapter interface methods unimplemented, expecting concrete subclasses
    // to provide them. Declare them abstract here so the C# compiler is satisfied.
    public abstract partial class AbstractExpandableItemAdapter
    {
        [Register("onCreateChildViewHolder", "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;",
            "GetOnCreateChildViewHolder_Landroid_view_ViewGroup_IHandler:Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable.IExpandableItemAdapterInvoker, Xamarin.Bindings.AdvancedRecyclerView")]
        public abstract global::Java.Lang.Object OnCreateChildViewHolder(ViewGroup parent, int viewType);

        [Register("onCreateGroupViewHolder", "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;",
            "GetOnCreateGroupViewHolder_Landroid_view_ViewGroup_IHandler:Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable.IExpandableItemAdapterInvoker, Xamarin.Bindings.AdvancedRecyclerView")]
        public abstract global::Java.Lang.Object OnCreateGroupViewHolder(ViewGroup parent, int viewType);

        [Register("onBindChildViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;III)V",
            "GetOnBindChildViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IIIHandler:Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable.IExpandableItemAdapterInvoker, Xamarin.Bindings.AdvancedRecyclerView")]
        public abstract void OnBindChildViewHolder(global::Java.Lang.Object viewHolder, int groupPosition, int childPosition, int viewType);

        [Register("onBindGroupViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;II)V",
            "GetOnBindGroupViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IIHandler:Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable.IExpandableItemAdapterInvoker, Xamarin.Bindings.AdvancedRecyclerView")]
        public abstract void OnBindGroupViewHolder(global::Java.Lang.Object viewHolder, int groupPosition, int viewType);

        [Register("onCheckCanExpandOrCollapseGroup", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;IIIZ)Z",
            "GetOnCheckCanExpandOrCollapseGroup_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IIIZHandler:Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable.IExpandableItemAdapterInvoker, Xamarin.Bindings.AdvancedRecyclerView")]
        public abstract bool OnCheckCanExpandOrCollapseGroup(global::Java.Lang.Object holder, int groupPosition, int x, int y, bool expand);
    }
}
