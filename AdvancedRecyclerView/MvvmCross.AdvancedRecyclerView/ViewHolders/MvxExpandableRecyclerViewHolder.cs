using System;
using Android.Runtime;
using Android.Views;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace MvvmCross.AdvancedRecyclerView.ViewHolders
{
    public class MvxExpandableRecyclerViewHolder : MvxAdvancedRecyclerViewHolder, IExpandableItemViewHolder
    {
        public MvxExpandableRecyclerViewHolder(View itemView, int swipeableContainerViewId, int underSwipeContainerViewId, IMvxAndroidBindingContext context) 
            : base(itemView, swipeableContainerViewId, underSwipeContainerViewId, context)
        {
        }

        public MvxExpandableRecyclerViewHolder(IntPtr handle, JniHandleOwnership ownership) : base(handle, ownership)
        {
        }

        public int ExpandStateFlags { get; set; }
    }
}