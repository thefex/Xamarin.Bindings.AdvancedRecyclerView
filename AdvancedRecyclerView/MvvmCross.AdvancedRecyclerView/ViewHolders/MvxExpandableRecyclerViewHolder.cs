using Android.Views;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MvvmCross.AdvancedRecyclerView.ViewHolders
{
    public class MvxExpandableRecyclerViewHolder : MvxRecyclerViewHolder
        , IExpandableItemViewHolder
    {
        public MvxExpandableRecyclerViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
        }

        public int ExpandStateFlags { get; set; }
    }
}