using System;
using System.Windows.Input;
using Android.Views;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Swipeable;
using Com.H6ah4i.Android.Widget.Advrecyclerview.Utils;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace MvvmCross.AdvancedRecyclerView.ViewHolders
{
    public class MvxAdvancedRecyclerViewHolder : AbstractSwipeableItemViewHolder, IMvxRecyclerViewHolder, IMvxBindingContextOwner
    {
        private readonly IMvxBindingContext _bindingContext;

        private object _cachedDataContext;
        private ICommand _click, _longClick;
        private bool _clickOverloaded, _longClickOverloaded;
        private View swipeableView;

        public MvxAdvancedRecyclerViewHolder(View itemView, int swipeableContainerViewId, int underSwipeContainerViewId, IMvxAndroidBindingContext context)
            : base(itemView)
        {
            swipeableView = itemView.FindViewById(swipeableContainerViewId);
            UnderSwipeableContainerView = itemView.FindViewById(underSwipeContainerViewId);
            _bindingContext = context;
        }

        public MvxAdvancedRecyclerViewHolder(IntPtr handle, Android.Runtime.JniHandleOwnership ownership) : base(handle, ownership)
        {
        }

        public override View SwipeableContainerView => swipeableView;

        public View UnderSwipeableContainerView { get; }

        public IMvxBindingContext BindingContext
        {
            get { return _bindingContext; }
            set { throw new NotImplementedException("BindingContext is readonly in the list item"); }
        }

        public object DataContext
        {
            get
            {
                return _bindingContext.DataContext;
            }
            set
            {
                _bindingContext.DataContext = value;

                // This is just a precaution.  If we've set the DataContext to something
                // then we don't need to have the old one still cached.
                if (value != null)
                    _cachedDataContext = null;
            }
        }

        public ICommand Click
        {
            get
            {
                return _click;
            }
            set
            {
                _click = value;
                if (_click != null)
                    EnsureClickOverloaded();
            }
        }

        private void EnsureClickOverloaded()
        {
            if (_clickOverloaded)
                return;
            _clickOverloaded = true;
            ItemView.Click += OnItemViewOnClick;
        }

        public ICommand LongClick
        {
            get
            {
                return _longClick;
            }
            set
            {
                _longClick = value;
                if (_longClick != null)
                    EnsureLongClickOverloaded();
            }
        }

        private void EnsureLongClickOverloaded()
        {
            if (_longClickOverloaded)
                return;
            _longClickOverloaded = true;
            ItemView.LongClick += OnItemViewOnLongClick;
        }

        protected virtual void ExecuteCommandOnItem(ICommand command)
        {
            if (command == null)
                return;

            var item = DataContext;
            if (item == null)
                return;

            if (!command.CanExecute(item))
                return;

            command.Execute(item);
        }

        private void OnItemViewOnClick(object sender, EventArgs args)
        {
            ExecuteCommandOnItem(Click);
        }

        private void OnItemViewOnLongClick(object sender, View.LongClickEventArgs args)
        {
            ExecuteCommandOnItem(LongClick);
        }

        public virtual void OnAttachedToWindow()
        {
            if (_cachedDataContext != null && DataContext == null)
                DataContext = _cachedDataContext;
        }

        public virtual void OnDetachedFromWindow()
        {
            _cachedDataContext = DataContext;
            DataContext = null;
        }

        public virtual void OnViewRecycled()
        {
            _cachedDataContext = null;
            DataContext = null;
        }

        protected override void Dispose(bool disposing)
        {
            // Clean up the binding context since nothing
            // explicitly Disposes of the ViewHolder.
            _bindingContext?.ClearAllBindings();

            if (disposing)
            {
                _cachedDataContext = null;

                if (ItemView != null)
                {
                    ItemView.Click -= OnItemViewOnClick;
                    ItemView.LongClick -= OnItemViewOnLongClick;
                }
            }

            base.Dispose(disposing);
        }
    }
}
