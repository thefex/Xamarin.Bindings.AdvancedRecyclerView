using Android.Views;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

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