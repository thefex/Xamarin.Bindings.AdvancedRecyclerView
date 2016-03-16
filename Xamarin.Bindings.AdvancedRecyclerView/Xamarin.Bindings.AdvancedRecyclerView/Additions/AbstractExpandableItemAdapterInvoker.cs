using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;

namespace Com.H6ah4i.Android.Widget.Advrecyclerview.Utils
{
    internal abstract partial class AbstractExpandableItemAdapterInvoker : AbstractExpandableItemAdapter, global::Com.H6ah4i.Android.Widget.Advrecyclerview.Expandable.IExpandableItemAdapter
    {

        //public AbstractExpandableItemAdapterInvoker(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer) { }

        //protected override global::System.Type ThresholdType
        //{
        //    get { return typeof(AbstractExpandableItemAdapterInvoker); }
        //}

        //static IntPtr id_getGroupCount;
        //public override unsafe int GroupCount
        //{
        //    // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.utils']/class[@name='AbstractExpandableItemAdapter']/method[@name='getGroupCount' and count(parameter)=0]"
        //    [Register("getGroupCount", "()I", "GetGetGroupCountHandler")]
        //    get
        //    {
        //        if (id_getGroupCount == IntPtr.Zero)
        //            id_getGroupCount = JNIEnv.GetMethodID(class_ref, "getGroupCount", "()I");
        //        try
        //        {
        //            return JNIEnv.CallIntMethod(Handle, id_getGroupCount);
        //        }
        //        finally
        //        {
        //        }
        //    }
        //}

        //static IntPtr id_getChildCount_I;
        //// Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.utils']/class[@name='AbstractExpandableItemAdapter']/method[@name='getChildCount' and count(parameter)=1 and parameter[1][@type='int']]"
        //[Register("getChildCount", "(I)I", "GetGetChildCount_IHandler")]
        //public override unsafe int GetChildCount(int p0)
        //{
        //    if (id_getChildCount_I == IntPtr.Zero)
        //        id_getChildCount_I = JNIEnv.GetMethodID(class_ref, "getChildCount", "(I)I");
        //    try
        //    {
        //        JValue* __args = stackalloc JValue[1];
        //        __args[0] = new JValue(p0);
        //        return JNIEnv.CallIntMethod(Handle, id_getChildCount_I, __args);
        //    }
        //    finally
        //    {
        //    }
        //}

        //static IntPtr id_getChildId_II;
        //// Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.utils']/class[@name='AbstractExpandableItemAdapter']/method[@name='getChildId' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
        //[Register("getChildId", "(II)J", "GetGetChildId_IIHandler")]
        //public override unsafe long GetChildId(int p0, int p1)
        //{
        //    if (id_getChildId_II == IntPtr.Zero)
        //        id_getChildId_II = JNIEnv.GetMethodID(class_ref, "getChildId", "(II)J");
        //    try
        //    {
        //        JValue* __args = stackalloc JValue[2];
        //        __args[0] = new JValue(p0);
        //        __args[1] = new JValue(p1);
        //        return JNIEnv.CallLongMethod(Handle, id_getChildId_II, __args);
        //    }
        //    finally
        //    {
        //    }
        //}

        //static IntPtr id_getChildItemViewType_II;
        //// Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.utils']/class[@name='AbstractExpandableItemAdapter']/method[@name='getChildItemViewType' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
        //[Register("getChildItemViewType", "(II)I", "GetGetChildItemViewType_IIHandler")]
        //public override unsafe int GetChildItemViewType(int p0, int p1)
        //{
        //    if (id_getChildItemViewType_II == IntPtr.Zero)
        //        id_getChildItemViewType_II = JNIEnv.GetMethodID(class_ref, "getChildItemViewType", "(II)I");
        //    try
        //    {
        //        JValue* __args = stackalloc JValue[2];
        //        __args[0] = new JValue(p0);
        //        __args[1] = new JValue(p1);
        //        return JNIEnv.CallIntMethod(Handle, id_getChildItemViewType_II, __args);
        //    }
        //    finally
        //    {
        //    }
        //}

        //static IntPtr id_getGroupId_I;
        //// Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.utils']/class[@name='AbstractExpandableItemAdapter']/method[@name='getGroupId' and count(parameter)=1 and parameter[1][@type='int']]"
        //[Register("getGroupId", "(I)J", "GetGetGroupId_IHandler")]
        //public override unsafe long GetGroupId(int p0)
        //{
        //    if (id_getGroupId_I == IntPtr.Zero)
        //        id_getGroupId_I = JNIEnv.GetMethodID(class_ref, "getGroupId", "(I)J");
        //    try
        //    {
        //        JValue* __args = stackalloc JValue[1];
        //        __args[0] = new JValue(p0);
        //        return JNIEnv.CallLongMethod(Handle, id_getGroupId_I, __args);
        //    }
        //    finally
        //    {
        //    }
        //}

        //static IntPtr id_getGroupItemViewType_I;
        //// Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.utils']/class[@name='AbstractExpandableItemAdapter']/method[@name='getGroupItemViewType' and count(parameter)=1 and parameter[1][@type='int']]"
        //[Register("getGroupItemViewType", "(I)I", "GetGetGroupItemViewType_IHandler")]
        //public override unsafe int GetGroupItemViewType(int p0)
        //{
        //    if (id_getGroupItemViewType_I == IntPtr.Zero)
        //        id_getGroupItemViewType_I = JNIEnv.GetMethodID(class_ref, "getGroupItemViewType", "(I)I");
        //    try
        //    {
        //        JValue* __args = stackalloc JValue[1];
        //        __args[0] = new JValue(p0);
        //        return JNIEnv.CallIntMethod(Handle, id_getGroupItemViewType_I, __args);
        //    }
        //    finally
        //    {
        //    }
        //}

    }
}