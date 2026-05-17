using System;
using Android.Runtime;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace Com.H6ah4i.Android.Widget.Advrecyclerview.Utils
{
    // onBindViewHolder(VH, int) and onCreateViewHolder(ViewGroup, int) are removed from the
    // generated API via Metadata.xml because the binder emits a JNI callback that casts VH
    // to Java.Lang.Object instead of RecyclerView.ViewHolder, causing a compile error.
    // This partial class provides correct hand-written implementations.
    public partial class BaseWrapperAdapter
    {
        // ── onBindViewHolder ────────────────────────────────────────────────────────

        static Delegate cb_onBindViewHolder_VH_I;
#pragma warning disable 0169
        static Delegate GetOnBindViewHolder_VH_IHandler()
        {
            if (cb_onBindViewHolder_VH_I == null)
                cb_onBindViewHolder_VH_I = JNINativeWrapper.CreateDelegate(
                    (Action<IntPtr, IntPtr, IntPtr, int>)n_OnBindViewHolder_VH_I);
            return cb_onBindViewHolder_VH_I;
        }

        static void n_OnBindViewHolder_VH_I(IntPtr jnienv, IntPtr native__this, IntPtr native_holder, int position)
        {
            var __this = global::Java.Lang.Object.GetObject<BaseWrapperAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            var holder = global::Java.Lang.Object.GetObject<RecyclerView.ViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
            __this.OnBindViewHolder(holder, position);
        }
#pragma warning restore 0169

        static IntPtr id_onBindViewHolder_VH_I;

        [Register("onBindViewHolder", "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V",
            "GetOnBindViewHolder_VH_IHandler")]
        public override unsafe void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (id_onBindViewHolder_VH_I == IntPtr.Zero)
                id_onBindViewHolder_VH_I = JNIEnv.GetMethodID(class_ref, "onBindViewHolder",
                    "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V");
            IntPtr native_holder = JNIEnv.ToLocalJniHandle(holder);
            try {
                JValue* __args = stackalloc JValue[2];
                __args[0] = new JValue(native_holder);
                __args[1] = new JValue(position);

                if (GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(Handle, id_onBindViewHolder_VH_I, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
                        JNIEnv.GetMethodID(ThresholdClass, "onBindViewHolder",
                            "(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V"), __args);
            } finally {
                JNIEnv.DeleteLocalRef(native_holder);
            }
        }

        // ── onCreateViewHolder ──────────────────────────────────────────────────────

        static Delegate cb_onCreateViewHolder_ViewGroup_I;
#pragma warning disable 0169
        static Delegate GetOnCreateViewHolder_ViewGroup_IHandler()
        {
            if (cb_onCreateViewHolder_ViewGroup_I == null)
                cb_onCreateViewHolder_ViewGroup_I = JNINativeWrapper.CreateDelegate(
                    (Func<IntPtr, IntPtr, IntPtr, int, IntPtr>)n_OnCreateViewHolder_ViewGroup_I);
            return cb_onCreateViewHolder_ViewGroup_I;
        }

        static IntPtr n_OnCreateViewHolder_ViewGroup_I(IntPtr jnienv, IntPtr native__this, IntPtr native_parent, int viewType)
        {
            var __this = global::Java.Lang.Object.GetObject<BaseWrapperAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            var parent = global::Java.Lang.Object.GetObject<ViewGroup>(native_parent, JniHandleOwnership.DoNotTransfer);
            return JNIEnv.ToLocalJniHandle(__this.OnCreateViewHolder(parent, viewType));
        }
#pragma warning restore 0169

        static IntPtr id_onCreateViewHolder_ViewGroup_I;

        [Register("onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;",
            "GetOnCreateViewHolder_ViewGroup_IHandler")]
        public override unsafe RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (id_onCreateViewHolder_ViewGroup_I == IntPtr.Zero)
                id_onCreateViewHolder_ViewGroup_I = JNIEnv.GetMethodID(class_ref, "onCreateViewHolder",
                    "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;");
            try {
                JValue* __args = stackalloc JValue[2];
                __args[0] = new JValue(parent);
                __args[1] = new JValue(viewType);

                global::Java.Lang.Object __ret;
                if (GetType() == ThresholdType)
                    __ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(
                        JNIEnv.CallObjectMethod(Handle, id_onCreateViewHolder_ViewGroup_I, __args),
                        JniHandleOwnership.TransferLocalRef);
                else
                    __ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(
                        JNIEnv.CallNonvirtualObjectMethod(Handle, ThresholdClass,
                            JNIEnv.GetMethodID(ThresholdClass, "onCreateViewHolder",
                                "(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;"),
                            __args),
                        JniHandleOwnership.TransferLocalRef);

                return __ret as RecyclerView.ViewHolder;
            } finally {
            }
        }
    }
}
