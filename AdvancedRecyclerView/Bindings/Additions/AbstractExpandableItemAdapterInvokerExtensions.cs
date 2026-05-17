using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Com.H6ah4i.Android.Widget.Advrecyclerview.Utils
{
    // Provide JNI-delegating implementations of the abstract methods we declared
    // in AbstractExpandableItemAdapterExtensions.cs so the generated invoker class compiles.
    internal abstract partial class AbstractExpandableItemAdapterInvoker
    {
        public override unsafe global::Java.Lang.Object OnCreateChildViewHolder(ViewGroup parent, int viewType)
        {
            const string __id = "onCreateChildViewHolder.(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;";
            try {
                JniArgumentValue* __args = stackalloc JniArgumentValue[2];
                __args[0] = new JniArgumentValue(parent);
                __args[1] = new JniArgumentValue(viewType);
                var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod(__id, this, __args);
                return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
            } finally {
                global::System.GC.KeepAlive(parent);
            }
        }

        public override unsafe global::Java.Lang.Object OnCreateGroupViewHolder(ViewGroup parent, int viewType)
        {
            const string __id = "onCreateGroupViewHolder.(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;";
            try {
                JniArgumentValue* __args = stackalloc JniArgumentValue[2];
                __args[0] = new JniArgumentValue(parent);
                __args[1] = new JniArgumentValue(viewType);
                var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod(__id, this, __args);
                return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
            } finally {
                global::System.GC.KeepAlive(parent);
            }
        }

        public override unsafe void OnBindChildViewHolder(global::Java.Lang.Object viewHolder, int groupPosition, int childPosition, int viewType)
        {
            const string __id = "onBindChildViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;III)V";
            try {
                JniArgumentValue* __args = stackalloc JniArgumentValue[4];
                __args[0] = new JniArgumentValue(viewHolder);
                __args[1] = new JniArgumentValue(groupPosition);
                __args[2] = new JniArgumentValue(childPosition);
                __args[3] = new JniArgumentValue(viewType);
                _members.InstanceMethods.InvokeAbstractVoidMethod(__id, this, __args);
            } finally {
                global::System.GC.KeepAlive(viewHolder);
            }
        }

        public override unsafe void OnBindGroupViewHolder(global::Java.Lang.Object viewHolder, int groupPosition, int viewType)
        {
            const string __id = "onBindGroupViewHolder.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;II)V";
            try {
                JniArgumentValue* __args = stackalloc JniArgumentValue[3];
                __args[0] = new JniArgumentValue(viewHolder);
                __args[1] = new JniArgumentValue(groupPosition);
                __args[2] = new JniArgumentValue(viewType);
                _members.InstanceMethods.InvokeAbstractVoidMethod(__id, this, __args);
            } finally {
                global::System.GC.KeepAlive(viewHolder);
            }
        }

        public override unsafe bool OnCheckCanExpandOrCollapseGroup(global::Java.Lang.Object holder, int groupPosition, int x, int y, bool expand)
        {
            const string __id = "onCheckCanExpandOrCollapseGroup.(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;IIIZ)Z";
            try {
                JniArgumentValue* __args = stackalloc JniArgumentValue[5];
                __args[0] = new JniArgumentValue(holder);
                __args[1] = new JniArgumentValue(groupPosition);
                __args[2] = new JniArgumentValue(x);
                __args[3] = new JniArgumentValue(y);
                __args[4] = new JniArgumentValue(expand);
                return _members.InstanceMethods.InvokeAbstractBooleanMethod(__id, this, __args);
            } finally {
                global::System.GC.KeepAlive(holder);
            }
        }
    }
}

