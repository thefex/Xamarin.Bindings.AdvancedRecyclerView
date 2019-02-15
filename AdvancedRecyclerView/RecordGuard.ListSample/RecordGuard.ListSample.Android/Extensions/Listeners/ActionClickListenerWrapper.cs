using System;
using Android.Runtime;
using Android.Views;

namespace RecordGuard.ListSample.Android.Extensions.Listeners
{
    public class ActionClickListenerWrapper : Java.Lang.Object, View.IOnClickListener
    {
        private readonly Action<View> _onClick;

        public ActionClickListenerWrapper(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public ActionClickListenerWrapper(Action<View> onClick)
        {
            _onClick = onClick;
        }

        public void OnClick(View v) => _onClick(v);
    }
}