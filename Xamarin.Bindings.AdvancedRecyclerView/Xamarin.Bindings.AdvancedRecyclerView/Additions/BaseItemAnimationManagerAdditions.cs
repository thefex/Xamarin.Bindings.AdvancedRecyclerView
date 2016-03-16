//using System;
//using System.Collections;
//using Android.Runtime;
//using Android.Support.V4.View;
//using Android.Support.V7.Widget;
//using Android.Views;
//using Java.Interop;
//using Object = Java.Lang.Object;

//namespace Com.H6ah4i.Android.Widget.Advrecyclerview.Animator.Impl
//{
//    // Metadata.xml XPath class reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']"
//    [Register("com/h6ah4i/android/widget/advrecyclerview/animator/impl/BaseItemAnimationManager",
//        DoNotGenerateAcw = true)]
//    [JavaTypeParameters(new[] {"T extends com.h6ah4i.android.widget.advrecyclerview.animator.impl.ItemAnimationInfo"})]
//    public abstract partial class BaseItemAnimationManager : Object
//    {
//        private static IntPtr mActive_jfieldId;

//        private static IntPtr mDeferredReadySets_jfieldId;

//        private static IntPtr mItemAnimator_jfieldId;

//        private static IntPtr mPending_jfieldId;


//        private static IntPtr
//            id_ctor_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_BaseItemAnimationManager_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_;

//        private static Delegate cb_onAnimationCancel_Landroid_view_View_;

//        private static IntPtr id_onAnimationCancel_Landroid_view_View_;

//        private static Delegate cb_onAnimationEnd_Landroid_view_View_;

//        private static IntPtr id_onAnimationEnd_Landroid_view_View_;

//        private static Delegate cb_onAnimationStart_Landroid_view_View_;

//        private static IntPtr id_onAnimationStart_Landroid_view_View_;


//        internal static IntPtr java_class_handle;

//        private static IntPtr id_ctor_Lcom_h6ah4i_android_widget_advrecyclerview_animator_BaseItemAnimator_;

//        private static Delegate cb_getDuration;

//        private static Delegate cb_setDuration_J;

//        private static Delegate cb_hasPending;

//        private static IntPtr id_hasPending;

//        private static Delegate cb_isRunning;

//        private static IntPtr id_isRunning;

//        private static Delegate cb_cancelAllStartedAnimations;

//        private static IntPtr id_cancelAllStartedAnimations;

//        private static IntPtr id_debugLogEnabled;

//        private static Delegate
//            cb_dispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static Delegate cb_dispatchFinishedWhenDone;

//        private static IntPtr id_dispatchFinishedWhenDone;

//        private static Delegate
//            cb_dispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static Delegate cb_endAllDeferredReadyAnimations;

//        private static IntPtr id_endAllDeferredReadyAnimations;

//        private static Delegate cb_endAllPendingAnimations;

//        private static IntPtr id_endAllPendingAnimations;

//        private static Delegate cb_endAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static IntPtr id_endAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static Delegate cb_endDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static IntPtr id_endDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static Delegate
//            cb_endNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static Delegate cb_endPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static IntPtr id_endPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static Delegate
//            cb_enqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_;

//        private static IntPtr
//            id_enqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_;

//        private static Delegate
//            cb_onAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static Delegate
//            cb_onAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static Delegate
//            cb_onAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static Delegate
//            cb_onCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_;

//        private static Delegate cb_removeFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static IntPtr id_removeFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static Delegate cb_runPendingAnimations_ZJ;

//        private static IntPtr id_runPendingAnimations_ZJ;

//        private static Delegate
//            cb_startActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_;

//        private static IntPtr
//            id_startActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_;

//        protected BaseItemAnimationManager(IntPtr javaReference, JniHandleOwnership transfer)
//            : base(javaReference, transfer)
//        {
//        }

//        // Metadata.xml XPath constructor reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/constructor[@name='BaseItemAnimationManager' and count(parameter)=1 and parameter[1][@type='com.h6ah4i.android.widget.advrecyclerview.animator.BaseItemAnimator']]"
//        [Register(".ctor", "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/BaseItemAnimator;)V", "")]
//        public unsafe BaseItemAnimationManager(BaseItemAnimator p0)
//            : base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
//        {
//            if (Handle != IntPtr.Zero)
//                return;

//            try
//            {
//                JValue* __args = stackalloc JValue[1];
//                __args[0] = new JValue(p0);
//                if (GetType() != typeof (BaseItemAnimationManager))
//                {
//                    SetHandle(
//                        JNIEnv.StartCreateInstance(GetType(),
//                            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/BaseItemAnimator;)V", __args),
//                        JniHandleOwnership.TransferLocalRef);
//                    JNIEnv.FinishCreateInstance(Handle,
//                        "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/BaseItemAnimator;)V", __args);
//                    return;
//                }

//                if (id_ctor_Lcom_h6ah4i_android_widget_advrecyclerview_animator_BaseItemAnimator_ == IntPtr.Zero)
//                    id_ctor_Lcom_h6ah4i_android_widget_advrecyclerview_animator_BaseItemAnimator_ =
//                        JNIEnv.GetMethodID(class_ref, "<init>",
//                            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/BaseItemAnimator;)V");
//                SetHandle(
//                    JNIEnv.StartCreateInstance(class_ref,
//                        id_ctor_Lcom_h6ah4i_android_widget_advrecyclerview_animator_BaseItemAnimator_, __args),
//                    JniHandleOwnership.TransferLocalRef);
//                JNIEnv.FinishCreateInstance(Handle, class_ref,
//                    id_ctor_Lcom_h6ah4i_android_widget_advrecyclerview_animator_BaseItemAnimator_, __args);
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath field reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/field[@name='mActive']"
//        [Register("mActive")]
//        protected IList MActive
//        {
//            get
//            {
//                if (mActive_jfieldId == IntPtr.Zero)
//                    mActive_jfieldId = JNIEnv.GetFieldID(class_ref, "mActive", "Ljava/util/List;");
//                var __ret = JNIEnv.GetObjectField(Handle, mActive_jfieldId);
//                return JavaList.FromJniHandle(__ret, JniHandleOwnership.TransferLocalRef);
//            }
//            set
//            {
//                if (mActive_jfieldId == IntPtr.Zero)
//                    mActive_jfieldId = JNIEnv.GetFieldID(class_ref, "mActive", "Ljava/util/List;");
//                var native_value = JavaList.ToLocalJniHandle(value);
//                try
//                {
//                    JNIEnv.SetField(Handle, mActive_jfieldId, native_value);
//                }
//                finally
//                {
//                    JNIEnv.DeleteLocalRef(native_value);
//                }
//            }
//        }

//        // Metadata.xml XPath field reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/field[@name='mDeferredReadySets']"
//        [Register("mDeferredReadySets")]
//        protected IList MDeferredReadySets
//        {
//            get
//            {
//                if (mDeferredReadySets_jfieldId == IntPtr.Zero)
//                    mDeferredReadySets_jfieldId = JNIEnv.GetFieldID(class_ref, "mDeferredReadySets", "Ljava/util/List;");
//                var __ret = JNIEnv.GetObjectField(Handle, mDeferredReadySets_jfieldId);
//                return JavaList.FromJniHandle(__ret, JniHandleOwnership.TransferLocalRef);
//            }
//            set
//            {
//                if (mDeferredReadySets_jfieldId == IntPtr.Zero)
//                    mDeferredReadySets_jfieldId = JNIEnv.GetFieldID(class_ref, "mDeferredReadySets", "Ljava/util/List;");
//                var native_value = JavaList.ToLocalJniHandle(value);
//                try
//                {
//                    JNIEnv.SetField(Handle, mDeferredReadySets_jfieldId, native_value);
//                }
//                finally
//                {
//                    JNIEnv.DeleteLocalRef(native_value);
//                }
//            }
//        }

//        // Metadata.xml XPath field reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/field[@name='mItemAnimator']"
//        [Register("mItemAnimator")]
//        protected BaseItemAnimator MItemAnimator
//        {
//            get
//            {
//                if (mItemAnimator_jfieldId == IntPtr.Zero)
//                    mItemAnimator_jfieldId = JNIEnv.GetFieldID(class_ref, "mItemAnimator",
//                        "Lcom/h6ah4i/android/widget/advrecyclerview/animator/BaseItemAnimator;");
//                var __ret = JNIEnv.GetObjectField(Handle, mItemAnimator_jfieldId);
//                return GetObject<BaseItemAnimator>(__ret, JniHandleOwnership.TransferLocalRef);
//            }
//            set
//            {
//                if (mItemAnimator_jfieldId == IntPtr.Zero)
//                    mItemAnimator_jfieldId = JNIEnv.GetFieldID(class_ref, "mItemAnimator",
//                        "Lcom/h6ah4i/android/widget/advrecyclerview/animator/BaseItemAnimator;");
//                var native_value = JNIEnv.ToLocalJniHandle(value);
//                try
//                {
//                    JNIEnv.SetField(Handle, mItemAnimator_jfieldId, native_value);
//                }
//                finally
//                {
//                    JNIEnv.DeleteLocalRef(native_value);
//                }
//            }
//        }

//        // Metadata.xml XPath field reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/field[@name='mPending']"
//        [Register("mPending")]
//        protected IList MPending
//        {
//            get
//            {
//                if (mPending_jfieldId == IntPtr.Zero)
//                    mPending_jfieldId = JNIEnv.GetFieldID(class_ref, "mPending", "Ljava/util/List;");
//                var __ret = JNIEnv.GetObjectField(Handle, mPending_jfieldId);
//                return JavaList.FromJniHandle(__ret, JniHandleOwnership.TransferLocalRef);
//            }
//            set
//            {
//                if (mPending_jfieldId == IntPtr.Zero)
//                    mPending_jfieldId = JNIEnv.GetFieldID(class_ref, "mPending", "Ljava/util/List;");
//                var native_value = JavaList.ToLocalJniHandle(value);
//                try
//                {
//                    JNIEnv.SetField(Handle, mPending_jfieldId, native_value);
//                }
//                finally
//                {
//                    JNIEnv.DeleteLocalRef(native_value);
//                }
//            }
//        }

//        internal static IntPtr class_ref
//        {
//            get
//            {
//                return
//                    JNIEnv.FindClass(
//                        "com/h6ah4i/android/widget/advrecyclerview/animator/impl/BaseItemAnimationManager",
//                        ref java_class_handle);
//            }
//        }

//        protected override IntPtr ThresholdClass
//        {
//            get { return class_ref; }
//        }

//        protected override Type ThresholdType
//        {
//            get { return typeof (BaseItemAnimationManager); }
//        }

//        public abstract long Duration {
//            // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='getDuration' and count(parameter)=0]"
//            [Register("getDuration", "()J", "GetGetDurationHandler")] get;
//            // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='setDuration' and count(parameter)=1 and parameter[1][@type='long']]"
//            [Register("setDuration", "(J)V", "GetSetDuration_JHandler")] set; }

//        public virtual bool HasPending
//        {
//            // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='hasPending' and count(parameter)=0]"
//            [Register("hasPending", "()Z", "GetHasPendingHandler")]
//            get
//            {
//                if (id_hasPending == IntPtr.Zero)
//                    id_hasPending = JNIEnv.GetMethodID(class_ref, "hasPending", "()Z");
//                try
//                {
//                    if (GetType() == ThresholdType)
//                        return JNIEnv.CallBooleanMethod(Handle, id_hasPending);
//                    else
//                        return JNIEnv.CallNonvirtualBooleanMethod(Handle, ThresholdClass,
//                            JNIEnv.GetMethodID(ThresholdClass, "hasPending", "()Z"));
//                }
//                finally
//                {
//                }
//            }
//        }

//        public virtual bool IsRunning
//        {
//            // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='isRunning' and count(parameter)=0]"
//            [Register("isRunning", "()Z", "GetIsRunningHandler")]
//            get
//            {
//                if (id_isRunning == IntPtr.Zero)
//                    id_isRunning = JNIEnv.GetMethodID(class_ref, "isRunning", "()Z");
//                try
//                {
//                    if (GetType() == ThresholdType)
//                        return JNIEnv.CallBooleanMethod(Handle, id_isRunning);
//                    else
//                        return JNIEnv.CallNonvirtualBooleanMethod(Handle, ThresholdClass,
//                            JNIEnv.GetMethodID(ThresholdClass, "isRunning", "()Z"));
//                }
//                finally
//                {
//                }
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager.BaseAnimatorListener']/method[@name='onAnimationCancel' and count(parameter)=1 and parameter[1][@type='android.view.View']]"
//        [Register("onAnimationCancel", "(Landroid/view/View;)V", "GetOnAnimationCancel_Landroid_view_View_Handler")]
//        public virtual unsafe void OnAnimationCancel(View p0)
//        {
//            if (id_onAnimationCancel_Landroid_view_View_ == IntPtr.Zero)
//                id_onAnimationCancel_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onAnimationCancel",
//                    "(Landroid/view/View;)V");
//            try
//            {
//                JValue* __args = stackalloc JValue[1];
//                __args[0] = new JValue(p0);

//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle, id_onAnimationCancel_Landroid_view_View_, __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "onAnimationCancel", "(Landroid/view/View;)V"), __args);
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager.BaseAnimatorListener']/method[@name='onAnimationEnd' and count(parameter)=1 and parameter[1][@type='android.view.View']]"
//        [Register("onAnimationEnd", "(Landroid/view/View;)V", "GetOnAnimationEnd_Landroid_view_View_Handler")]
//        public virtual unsafe void OnAnimationEnd(View p0)
//        {
//            if (id_onAnimationEnd_Landroid_view_View_ == IntPtr.Zero)
//                id_onAnimationEnd_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onAnimationEnd",
//                    "(Landroid/view/View;)V");
//            try
//            {
//                JValue* __args = stackalloc JValue[1];
//                __args[0] = new JValue(p0);

//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle, id_onAnimationEnd_Landroid_view_View_, __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "onAnimationEnd", "(Landroid/view/View;)V"), __args);
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager.BaseAnimatorListener']/method[@name='onAnimationStart' and count(parameter)=1 and parameter[1][@type='android.view.View']]"
//        [Register("onAnimationStart", "(Landroid/view/View;)V", "GetOnAnimationStart_Landroid_view_View_Handler")]
//        public virtual unsafe void OnAnimationStart(View p0)
//        {
//            if (id_onAnimationStart_Landroid_view_View_ == IntPtr.Zero)
//                id_onAnimationStart_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onAnimationStart",
//                    "(Landroid/view/View;)V");
//            try
//            {
//                JValue* __args = stackalloc JValue[1];
//                __args[0] = new JValue(p0);

//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle, id_onAnimationStart_Landroid_view_View_, __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "onAnimationStart", "(Landroid/view/View;)V"), __args);
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='cancelAllStartedAnimations' and count(parameter)=0]"
//        [Register("cancelAllStartedAnimations", "()V", "GetCancelAllStartedAnimationsHandler")]
//        public virtual void CancelAllStartedAnimations()
//        {
//            if (id_cancelAllStartedAnimations == IntPtr.Zero)
//                id_cancelAllStartedAnimations = JNIEnv.GetMethodID(class_ref, "cancelAllStartedAnimations", "()V");
//            try
//            {
//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle, id_cancelAllStartedAnimations);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "cancelAllStartedAnimations", "()V"));
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='debugLogEnabled' and count(parameter)=0]"
//        [Register("debugLogEnabled", "()Z", "")]
//        protected bool DebugLogEnabled()
//        {
//            if (id_debugLogEnabled == IntPtr.Zero)
//                id_debugLogEnabled = JNIEnv.GetMethodID(class_ref, "debugLogEnabled", "()Z");
//            try
//            {
//                return JNIEnv.CallBooleanMethod(Handle, id_debugLogEnabled);
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='dispatchFinished' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("dispatchFinished",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetDispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        public abstract void DispatchFinished(Object p0, RecyclerView.ViewHolder p1);

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='dispatchFinishedWhenDone' and count(parameter)=0]"
//        [Register("dispatchFinishedWhenDone", "()V", "GetDispatchFinishedWhenDoneHandler")]
//        protected virtual void DispatchFinishedWhenDone()
//        {
//            if (id_dispatchFinishedWhenDone == IntPtr.Zero)
//                id_dispatchFinishedWhenDone = JNIEnv.GetMethodID(class_ref, "dispatchFinishedWhenDone", "()V");
//            try
//            {
//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle, id_dispatchFinishedWhenDone);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "dispatchFinishedWhenDone", "()V"));
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='dispatchStarting' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("dispatchStarting",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetDispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        public abstract void DispatchStarting(Object p0, RecyclerView.ViewHolder p1);

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='endAllDeferredReadyAnimations' and count(parameter)=0]"
//        [Register("endAllDeferredReadyAnimations", "()V", "GetEndAllDeferredReadyAnimationsHandler")]
//        public virtual void EndAllDeferredReadyAnimations()
//        {
//            if (id_endAllDeferredReadyAnimations == IntPtr.Zero)
//                id_endAllDeferredReadyAnimations = JNIEnv.GetMethodID(class_ref, "endAllDeferredReadyAnimations", "()V");
//            try
//            {
//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle, id_endAllDeferredReadyAnimations);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "endAllDeferredReadyAnimations", "()V"));
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='endAllPendingAnimations' and count(parameter)=0]"
//        [Register("endAllPendingAnimations", "()V", "GetEndAllPendingAnimationsHandler")]
//        public virtual void EndAllPendingAnimations()
//        {
//            if (id_endAllPendingAnimations == IntPtr.Zero)
//                id_endAllPendingAnimations = JNIEnv.GetMethodID(class_ref, "endAllPendingAnimations", "()V");
//            try
//            {
//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle, id_endAllPendingAnimations);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "endAllPendingAnimations", "()V"));
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='endAnimation' and count(parameter)=1 and parameter[1][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("endAnimation", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetEndAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler")]
//        protected virtual unsafe void EndAnimation(RecyclerView.ViewHolder p0)
//        {
//            if (id_endAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_ == IntPtr.Zero)
//                id_endAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_ = JNIEnv.GetMethodID(class_ref,
//                    "endAnimation", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)V");
//            try
//            {
//                JValue* __args = stackalloc JValue[1];
//                __args[0] = new JValue(p0);

//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle, id_endAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_,
//                        __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "endAnimation",
//                            "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)V"), __args);
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='endDeferredReadyAnimations' and count(parameter)=1 and parameter[1][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("endDeferredReadyAnimations", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetEndDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler")]
//        public virtual unsafe void EndDeferredReadyAnimations(RecyclerView.ViewHolder p0)
//        {
//            if (id_endDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_ == IntPtr.Zero)
//                id_endDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_ =
//                    JNIEnv.GetMethodID(class_ref, "endDeferredReadyAnimations",
//                        "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)V");
//            try
//            {
//                JValue* __args = stackalloc JValue[1];
//                __args[0] = new JValue(p0);

//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle,
//                        id_endDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_, __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "endDeferredReadyAnimations",
//                            "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)V"), __args);
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='endNotStartedAnimation' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("endNotStartedAnimation",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)Z",
//            "GetEndNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        protected abstract bool EndNotStartedAnimation(Object p0, RecyclerView.ViewHolder p1);

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='endPendingAnimations' and count(parameter)=1 and parameter[1][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("endPendingAnimations", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetEndPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler")]
//        public virtual unsafe void EndPendingAnimations(RecyclerView.ViewHolder p0)
//        {
//            if (id_endPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_ == IntPtr.Zero)
//                id_endPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_ =
//                    JNIEnv.GetMethodID(class_ref, "endPendingAnimations",
//                        "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)V");
//            try
//            {
//                JValue* __args = stackalloc JValue[1];
//                __args[0] = new JValue(p0);

//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle,
//                        id_endPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_, __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "endPendingAnimations",
//                            "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)V"), __args);
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='enqueuePendingAnimationInfo' and count(parameter)=1 and parameter[1][@type='T']]"
//        [Register("enqueuePendingAnimationInfo",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;)V",
//            "GetEnqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Handler"
//            )]
//        protected virtual unsafe void EnqueuePendingAnimationInfo(Object p0)
//        {
//            if (
//                id_enqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_ ==
//                IntPtr.Zero)
//                id_enqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_
//                    = JNIEnv.GetMethodID(class_ref, "enqueuePendingAnimationInfo",
//                        "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;)V");
//            var native_p0 = JNIEnv.ToLocalJniHandle(p0);
//            try
//            {
//                JValue* __args = stackalloc JValue[1];
//                __args[0] = new JValue(native_p0);

//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle,
//                        id_enqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_,
//                        __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "enqueuePendingAnimationInfo",
//                            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;)V"), __args);
//            }
//            finally
//            {
//                JNIEnv.DeleteLocalRef(native_p0);
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='onAnimationCancel' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("onAnimationCancel",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetOnAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        protected abstract void OnAnimationCancel(Object p0, RecyclerView.ViewHolder p1);

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='onAnimationEndedBeforeStarted' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("onAnimationEndedBeforeStarted",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetOnAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        protected abstract void OnAnimationEndedBeforeStarted(Object p0, RecyclerView.ViewHolder p1);

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='onAnimationEndedSuccessfully' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("onAnimationEndedSuccessfully",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetOnAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        protected abstract void OnAnimationEndedSuccessfully(Object p0, RecyclerView.ViewHolder p1);

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='onCreateAnimation' and count(parameter)=1 and parameter[1][@type='T']]"
//        [Register("onCreateAnimation", "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;)V",
//            "GetOnCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Handler")]
//        protected abstract void OnCreateAnimation(Object p0);

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='removeFromActive' and count(parameter)=1 and parameter[1][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("removeFromActive", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)Z",
//            "GetRemoveFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler")]
//        public virtual unsafe bool RemoveFromActive(RecyclerView.ViewHolder p0)
//        {
//            if (id_removeFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_ == IntPtr.Zero)
//                id_removeFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_ = JNIEnv.GetMethodID(class_ref,
//                    "removeFromActive", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)Z");
//            try
//            {
//                JValue* __args = stackalloc JValue[1];
//                __args[0] = new JValue(p0);

//                bool __ret;
//                if (GetType() == ThresholdType)
//                    __ret = JNIEnv.CallBooleanMethod(Handle,
//                        id_removeFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_, __args);
//                else
//                    __ret = JNIEnv.CallNonvirtualBooleanMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "removeFromActive",
//                            "(Landroid/support/v7/widget/RecyclerView$ViewHolder;)Z"), __args);
//                return __ret;
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='runPendingAnimations' and count(parameter)=2 and parameter[1][@type='boolean'] and parameter[2][@type='long']]"
//        [Register("runPendingAnimations", "(ZJ)V", "GetRunPendingAnimations_ZJHandler")]
//        public virtual unsafe void RunPendingAnimations(bool p0, long p1)
//        {
//            if (id_runPendingAnimations_ZJ == IntPtr.Zero)
//                id_runPendingAnimations_ZJ = JNIEnv.GetMethodID(class_ref, "runPendingAnimations", "(ZJ)V");
//            try
//            {
//                JValue* __args = stackalloc JValue[2];
//                __args[0] = new JValue(p0);
//                __args[1] = new JValue(p1);

//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle, id_runPendingAnimations_ZJ, __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "runPendingAnimations", "(ZJ)V"), __args);
//            }
//            finally
//            {
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='startActiveItemAnimation' and count(parameter)=3 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder'] and parameter[3][@type='android.support.v4.view.ViewPropertyAnimatorCompat']]"
//        [Register("startActiveItemAnimation",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;Landroid/support/v4/view/ViewPropertyAnimatorCompat;)V",
//            "GetStartActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_Handler"
//            )]
//        protected virtual unsafe void StartActiveItemAnimation(Object p0, RecyclerView.ViewHolder p1,
//            ViewPropertyAnimatorCompat p2)
//        {
//            if (
//                id_startActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_ ==
//                IntPtr.Zero)
//                id_startActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_
//                    = JNIEnv.GetMethodID(class_ref, "startActiveItemAnimation",
//                        "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;Landroid/support/v4/view/ViewPropertyAnimatorCompat;)V");
//            var native_p0 = JNIEnv.ToLocalJniHandle(p0);
//            try
//            {
//                JValue* __args = stackalloc JValue[3];
//                __args[0] = new JValue(native_p0);
//                __args[1] = new JValue(p1);
//                __args[2] = new JValue(p2);

//                if (GetType() == ThresholdType)
//                    JNIEnv.CallVoidMethod(Handle,
//                        id_startActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_,
//                        __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass,
//                        JNIEnv.GetMethodID(ThresholdClass, "startActiveItemAnimation",
//                            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;Landroid/support/v4/view/ViewPropertyAnimatorCompat;)V"),
//                        __args);
//            }
//            finally
//            {
//                JNIEnv.DeleteLocalRef(native_p0);
//            }
//        }
//#pragma warning disable 0169
//        private static Delegate GetOnAnimationCancel_Landroid_view_View_Handler()
//        {
//            if (cb_onAnimationCancel_Landroid_view_View_ == null)
//                cb_onAnimationCancel_Landroid_view_View_ =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr>) n_OnAnimationCancel_Landroid_view_View_);
//            return cb_onAnimationCancel_Landroid_view_View_;
//        }

//        private static void n_OnAnimationCancel_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//        {
//            var __this = GetObject<BaseAnimatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
//            __this.OnAnimationCancel(p0);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetOnAnimationEnd_Landroid_view_View_Handler()
//        {
//            if (cb_onAnimationEnd_Landroid_view_View_ == null)
//                cb_onAnimationEnd_Landroid_view_View_ =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr>) n_OnAnimationEnd_Landroid_view_View_);
//            return cb_onAnimationEnd_Landroid_view_View_;
//        }

//        private static void n_OnAnimationEnd_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//        {
//            var __this = GetObject<BaseAnimatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
//            __this.OnAnimationEnd(p0);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetOnAnimationStart_Landroid_view_View_Handler()
//        {
//            if (cb_onAnimationStart_Landroid_view_View_ == null)
//                cb_onAnimationStart_Landroid_view_View_ =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr>) n_OnAnimationStart_Landroid_view_View_);
//            return cb_onAnimationStart_Landroid_view_View_;
//        }

//        private static void n_OnAnimationStart_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//        {
//            var __this = GetObject<BaseAnimatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<View>(native_p0, JniHandleOwnership.DoNotTransfer);
//            __this.OnAnimationStart(p0);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetGetDurationHandler()
//        {
//            if (cb_getDuration == null)
//                cb_getDuration = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, long>) n_GetDuration);
//            return cb_getDuration;
//        }

//        private static long n_GetDuration(IntPtr jnienv, IntPtr native__this)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            return __this.Duration;
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetSetDuration_JHandler()
//        {
//            if (cb_setDuration_J == null)
//                cb_setDuration_J = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, long>) n_SetDuration_J);
//            return cb_setDuration_J;
//        }

//        private static void n_SetDuration_J(IntPtr jnienv, IntPtr native__this, long p0)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            __this.Duration = p0;
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetHasPendingHandler()
//        {
//            if (cb_hasPending == null)
//                cb_hasPending = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, bool>) n_HasPending);
//            return cb_hasPending;
//        }

//        private static bool n_HasPending(IntPtr jnienv, IntPtr native__this)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            return __this.HasPending;
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetIsRunningHandler()
//        {
//            if (cb_isRunning == null)
//                cb_isRunning = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, bool>) n_IsRunning);
//            return cb_isRunning;
//        }

//        private static bool n_IsRunning(IntPtr jnienv, IntPtr native__this)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            return __this.IsRunning;
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetCancelAllStartedAnimationsHandler()
//        {
//            if (cb_cancelAllStartedAnimations == null)
//                cb_cancelAllStartedAnimations =
//                    JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr>) n_CancelAllStartedAnimations);
//            return cb_cancelAllStartedAnimations;
//        }

//        private static void n_CancelAllStartedAnimations(IntPtr jnienv, IntPtr native__this)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            __this.CancelAllStartedAnimations();
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate
//            GetDispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler
//            ()
//        {
//            if (
//                cb_dispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                null)
//                cb_dispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr, IntPtr>)
//                            n_DispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_);
//            return
//                cb_dispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;
//        }

//        private static void
//            n_DispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//            (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<Object>(native_p0, JniHandleOwnership.DoNotTransfer);
//            var p1 = GetObject<RecyclerView.ViewHolder>(native_p1, JniHandleOwnership.DoNotTransfer);
//            __this.DispatchFinished(p0, p1);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetDispatchFinishedWhenDoneHandler()
//        {
//            if (cb_dispatchFinishedWhenDone == null)
//                cb_dispatchFinishedWhenDone =
//                    JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr>) n_DispatchFinishedWhenDone);
//            return cb_dispatchFinishedWhenDone;
//        }

//        private static void n_DispatchFinishedWhenDone(IntPtr jnienv, IntPtr native__this)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            __this.DispatchFinishedWhenDone();
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate
//            GetDispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler
//            ()
//        {
//            if (
//                cb_dispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                null)
//                cb_dispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr, IntPtr>)
//                            n_DispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_);
//            return
//                cb_dispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;
//        }

//        private static void
//            n_DispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//            (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<Object>(native_p0, JniHandleOwnership.DoNotTransfer);
//            var p1 = GetObject<RecyclerView.ViewHolder>(native_p1, JniHandleOwnership.DoNotTransfer);
//            __this.DispatchStarting(p0, p1);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetEndAllDeferredReadyAnimationsHandler()
//        {
//            if (cb_endAllDeferredReadyAnimations == null)
//                cb_endAllDeferredReadyAnimations =
//                    JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr>) n_EndAllDeferredReadyAnimations);
//            return cb_endAllDeferredReadyAnimations;
//        }

//        private static void n_EndAllDeferredReadyAnimations(IntPtr jnienv, IntPtr native__this)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            __this.EndAllDeferredReadyAnimations();
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetEndAllPendingAnimationsHandler()
//        {
//            if (cb_endAllPendingAnimations == null)
//                cb_endAllPendingAnimations =
//                    JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr>) n_EndAllPendingAnimations);
//            return cb_endAllPendingAnimations;
//        }

//        private static void n_EndAllPendingAnimations(IntPtr jnienv, IntPtr native__this)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            __this.EndAllPendingAnimations();
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetEndAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler()
//        {
//            if (cb_endAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_ == null)
//                cb_endAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_ =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr>)
//                            n_EndAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_);
//            return cb_endAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_;
//        }

//        private static void n_EndAnimation_Landroid_support_v7_widget_RecyclerView_ViewHolder_(IntPtr jnienv,
//            IntPtr native__this, IntPtr native_p0)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<RecyclerView.ViewHolder>(native_p0, JniHandleOwnership.DoNotTransfer);
//            __this.EndAnimation(p0);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetEndDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler
//            ()
//        {
//            if (cb_endDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_ == null)
//                cb_endDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_ =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr>)
//                            n_EndDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_);
//            return cb_endDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_;
//        }

//        private static void n_EndDeferredReadyAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_(
//            IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<RecyclerView.ViewHolder>(native_p0, JniHandleOwnership.DoNotTransfer);
//            __this.EndDeferredReadyAnimations(p0);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate
//            GetEndNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler
//            ()
//        {
//            if (
//                cb_endNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                null)
//                cb_endNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    =
//                    JNINativeWrapper.CreateDelegate(
//                        (Func<IntPtr, IntPtr, IntPtr, IntPtr, bool>)
//                            n_EndNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_);
//            return
//                cb_endNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;
//        }

//        private static bool
//            n_EndNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//            (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<Object>(native_p0, JniHandleOwnership.DoNotTransfer);
//            var p1 = GetObject<RecyclerView.ViewHolder>(native_p1, JniHandleOwnership.DoNotTransfer);
//            bool __ret = __this.EndNotStartedAnimation(p0, p1);
//            return __ret;
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetEndPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler()
//        {
//            if (cb_endPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_ == null)
//                cb_endPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_ =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr>)
//                            n_EndPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_);
//            return cb_endPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_;
//        }

//        private static void n_EndPendingAnimations_Landroid_support_v7_widget_RecyclerView_ViewHolder_(IntPtr jnienv,
//            IntPtr native__this, IntPtr native_p0)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<RecyclerView.ViewHolder>(native_p0, JniHandleOwnership.DoNotTransfer);
//            __this.EndPendingAnimations(p0);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate
//            GetEnqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Handler
//            ()
//        {
//            if (
//                cb_enqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_ ==
//                null)
//                cb_enqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_
//                    =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr>)
//                            n_EnqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_);
//            return
//                cb_enqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_;
//        }

//        private static void
//            n_EnqueuePendingAnimationInfo_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_(
//            IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<Object>(native_p0, JniHandleOwnership.DoNotTransfer);
//            __this.EnqueuePendingAnimationInfo(p0);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate
//            GetOnAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler
//            ()
//        {
//            if (
//                cb_onAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                null)
//                cb_onAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr, IntPtr>)
//                            n_OnAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_);
//            return
//                cb_onAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;
//        }

//        private static void
//            n_OnAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//            (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<Object>(native_p0, JniHandleOwnership.DoNotTransfer);
//            var p1 = GetObject<RecyclerView.ViewHolder>(native_p1, JniHandleOwnership.DoNotTransfer);
//            __this.OnAnimationCancel(p0, p1);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate
//            GetOnAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler
//            ()
//        {
//            if (
//                cb_onAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                null)
//                cb_onAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr, IntPtr>)
//                            n_OnAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_);
//            return
//                cb_onAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;
//        }

//        private static void
//            n_OnAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//            (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<Object>(native_p0, JniHandleOwnership.DoNotTransfer);
//            var p1 = GetObject<RecyclerView.ViewHolder>(native_p1, JniHandleOwnership.DoNotTransfer);
//            __this.OnAnimationEndedBeforeStarted(p0, p1);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate
//            GetOnAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler
//            ()
//        {
//            if (
//                cb_onAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                null)
//                cb_onAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr, IntPtr>)
//                            n_OnAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_);
//            return
//                cb_onAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;
//        }

//        private static void
//            n_OnAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//            (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<Object>(native_p0, JniHandleOwnership.DoNotTransfer);
//            var p1 = GetObject<RecyclerView.ViewHolder>(native_p1, JniHandleOwnership.DoNotTransfer);
//            __this.OnAnimationEndedSuccessfully(p0, p1);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate
//            GetOnCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Handler()
//        {
//            if (cb_onCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_ == null)
//                cb_onCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_ =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr>)
//                            n_OnCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_);
//            return cb_onCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_;
//        }

//        private static void
//            n_OnCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_(
//            IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<Object>(native_p0, JniHandleOwnership.DoNotTransfer);
//            __this.OnCreateAnimation(p0);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetRemoveFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler()
//        {
//            if (cb_removeFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_ == null)
//                cb_removeFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_ =
//                    JNINativeWrapper.CreateDelegate(
//                        (Func<IntPtr, IntPtr, IntPtr, bool>)
//                            n_RemoveFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_);
//            return cb_removeFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_;
//        }

//        private static bool n_RemoveFromActive_Landroid_support_v7_widget_RecyclerView_ViewHolder_(IntPtr jnienv,
//            IntPtr native__this, IntPtr native_p0)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<RecyclerView.ViewHolder>(native_p0, JniHandleOwnership.DoNotTransfer);
//            bool __ret = __this.RemoveFromActive(p0);
//            return __ret;
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate GetRunPendingAnimations_ZJHandler()
//        {
//            if (cb_runPendingAnimations_ZJ == null)
//                cb_runPendingAnimations_ZJ =
//                    JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, bool, long>) n_RunPendingAnimations_ZJ);
//            return cb_runPendingAnimations_ZJ;
//        }

//        private static void n_RunPendingAnimations_ZJ(IntPtr jnienv, IntPtr native__this, bool p0, long p1)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            __this.RunPendingAnimations(p0, p1);
//        }
//#pragma warning restore 0169
//#pragma warning disable 0169
//        private static Delegate
//            GetStartActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_Handler
//            ()
//        {
//            if (
//                cb_startActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_ ==
//                null)
//                cb_startActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_
//                    =
//                    JNINativeWrapper.CreateDelegate(
//                        (Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)
//                            n_StartActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_);
//            return
//                cb_startActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_;
//        }

//        private static void
//            n_StartActiveItemAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Landroid_support_v4_view_ViewPropertyAnimatorCompat_
//            (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
//        {
//            var __this = GetObject<BaseItemAnimationManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            var p0 = GetObject<Object>(native_p0, JniHandleOwnership.DoNotTransfer);
//            var p1 = GetObject<RecyclerView.ViewHolder>(native_p1, JniHandleOwnership.DoNotTransfer);
//            var p2 = GetObject<ViewPropertyAnimatorCompat>(native_p2, JniHandleOwnership.DoNotTransfer);
//            __this.StartActiveItemAnimation(p0, p1, p2);
//        }
//#pragma warning restore 0169
//    }

//    [Register("com/h6ah4i/android/widget/advrecyclerview/animator/impl/BaseItemAnimationManager",
//        DoNotGenerateAcw = true)]
//    internal partial class BaseItemAnimationManagerInvoker : BaseItemAnimationManager
//    {
//        private static IntPtr id_getDuration;
//        private static IntPtr id_setDuration_J;

//        private static IntPtr
//            id_dispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static IntPtr
//            id_dispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static IntPtr
//            id_endNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static IntPtr
//            id_onAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static IntPtr
//            id_onAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static IntPtr
//            id_onAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_;

//        private static IntPtr
//            id_onCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_;

//        public BaseItemAnimationManagerInvoker(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
//        {
//        }

//        protected override Type ThresholdType
//        {
//            get { return typeof (BaseItemAnimationManagerInvoker); }
//        }

//        public override unsafe long Duration
//        {
//            // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='getDuration' and count(parameter)=0]"
//            [Register("getDuration", "()J", "GetGetDurationHandler")]
//            get
//            {
//                if (id_getDuration == IntPtr.Zero)
//                    id_getDuration = JNIEnv.GetMethodID(class_ref, "getDuration", "()J");
//                try
//                {
//                    return JNIEnv.CallLongMethod(Handle, id_getDuration);
//                }
//                finally
//                {
//                }
//            }
//            // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='setDuration' and count(parameter)=1 and parameter[1][@type='long']]"
//            [Register("setDuration", "(J)V", "GetSetDuration_JHandler")]
//            set
//            {
//                if (id_setDuration_J == IntPtr.Zero)
//                    id_setDuration_J = JNIEnv.GetMethodID(class_ref, "setDuration", "(J)V");
//                try
//                {
//                    JValue* __args = stackalloc JValue[1];
//                    __args[0] = new JValue(value);
//                    JNIEnv.CallVoidMethod(Handle, id_setDuration_J, __args);
//                }
//                finally
//                {
//                }
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='dispatchFinished' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("dispatchFinished",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetDispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        public override unsafe void DispatchFinished(Object p0, RecyclerView.ViewHolder p1)
//        {
//            if (
//                id_dispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                IntPtr.Zero)
//                id_dispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    = JNIEnv.GetMethodID(class_ref, "dispatchFinished",
//                        "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V");
//            var native_p0 = JNIEnv.ToLocalJniHandle(p0);
//            try
//            {
//                JValue* __args = stackalloc JValue[2];
//                __args[0] = new JValue(native_p0);
//                __args[1] = new JValue(p1);
//                JNIEnv.CallVoidMethod(Handle,
//                    id_dispatchFinished_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_,
//                    __args);
//            }
//            finally
//            {
//                JNIEnv.DeleteLocalRef(native_p0);
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='dispatchStarting' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("dispatchStarting",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetDispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        public override unsafe void DispatchStarting(Object p0, RecyclerView.ViewHolder p1)
//        {
//            if (
//                id_dispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                IntPtr.Zero)
//                id_dispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    = JNIEnv.GetMethodID(class_ref, "dispatchStarting",
//                        "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V");
//            var native_p0 = JNIEnv.ToLocalJniHandle(p0);
//            try
//            {
//                JValue* __args = stackalloc JValue[2];
//                __args[0] = new JValue(native_p0);
//                __args[1] = new JValue(p1);
//                JNIEnv.CallVoidMethod(Handle,
//                    id_dispatchStarting_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_,
//                    __args);
//            }
//            finally
//            {
//                JNIEnv.DeleteLocalRef(native_p0);
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='endNotStartedAnimation' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("endNotStartedAnimation",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)Z",
//            "GetEndNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        protected override unsafe bool EndNotStartedAnimation(Object p0, RecyclerView.ViewHolder p1)
//        {
//            if (
//                id_endNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                IntPtr.Zero)
//                id_endNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    = JNIEnv.GetMethodID(class_ref, "endNotStartedAnimation",
//                        "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)Z");
//            var native_p0 = JNIEnv.ToLocalJniHandle(p0);
//            try
//            {
//                JValue* __args = stackalloc JValue[2];
//                __args[0] = new JValue(native_p0);
//                __args[1] = new JValue(p1);
//                var __ret = JNIEnv.CallBooleanMethod(Handle,
//                    id_endNotStartedAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_,
//                    __args);
//                return __ret;
//            }
//            finally
//            {
//                JNIEnv.DeleteLocalRef(native_p0);
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='onAnimationCancel' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("onAnimationCancel",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetOnAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        protected override unsafe void OnAnimationCancel(Object p0, RecyclerView.ViewHolder p1)
//        {
//            if (
//                id_onAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                IntPtr.Zero)
//                id_onAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    = JNIEnv.GetMethodID(class_ref, "onAnimationCancel",
//                        "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V");
//            var native_p0 = JNIEnv.ToLocalJniHandle(p0);
//            try
//            {
//                JValue* __args = stackalloc JValue[2];
//                __args[0] = new JValue(native_p0);
//                __args[1] = new JValue(p1);
//                JNIEnv.CallVoidMethod(Handle,
//                    id_onAnimationCancel_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_,
//                    __args);
//            }
//            finally
//            {
//                JNIEnv.DeleteLocalRef(native_p0);
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='onAnimationEndedBeforeStarted' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("onAnimationEndedBeforeStarted",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetOnAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        protected override unsafe void OnAnimationEndedBeforeStarted(Object p0, RecyclerView.ViewHolder p1)
//        {
//            if (
//                id_onAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                IntPtr.Zero)
//                id_onAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    = JNIEnv.GetMethodID(class_ref, "onAnimationEndedBeforeStarted",
//                        "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V");
//            var native_p0 = JNIEnv.ToLocalJniHandle(p0);
//            try
//            {
//                JValue* __args = stackalloc JValue[2];
//                __args[0] = new JValue(native_p0);
//                __args[1] = new JValue(p1);
//                JNIEnv.CallVoidMethod(Handle,
//                    id_onAnimationEndedBeforeStarted_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_,
//                    __args);
//            }
//            finally
//            {
//                JNIEnv.DeleteLocalRef(native_p0);
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='onAnimationEndedSuccessfully' and count(parameter)=2 and parameter[1][@type='T'] and parameter[2][@type='android.support.v7.widget.RecyclerView.ViewHolder']]"
//        [Register("onAnimationEndedSuccessfully",
//            "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V",
//            "GetOnAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_Handler"
//            )]
//        protected override unsafe void OnAnimationEndedSuccessfully(Object p0, RecyclerView.ViewHolder p1)
//        {
//            if (
//                id_onAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_ ==
//                IntPtr.Zero)
//                id_onAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_
//                    = JNIEnv.GetMethodID(class_ref, "onAnimationEndedSuccessfully",
//                        "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;Landroid/support/v7/widget/RecyclerView$ViewHolder;)V");
//            var native_p0 = JNIEnv.ToLocalJniHandle(p0);
//            try
//            {
//                JValue* __args = stackalloc JValue[2];
//                __args[0] = new JValue(native_p0);
//                __args[1] = new JValue(p1);
//                JNIEnv.CallVoidMethod(Handle,
//                    id_onAnimationEndedSuccessfully_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Landroid_support_v7_widget_RecyclerView_ViewHolder_,
//                    __args);
//            }
//            finally
//            {
//                JNIEnv.DeleteLocalRef(native_p0);
//            }
//        }

//        // Metadata.xml XPath method reference: path="/api/package[@name='com.h6ah4i.android.widget.advrecyclerview.animator.impl']/class[@name='BaseItemAnimationManager']/method[@name='onCreateAnimation' and count(parameter)=1 and parameter[1][@type='T']]"
//        [Register("onCreateAnimation", "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;)V",
//            "GetOnCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_Handler")]
//        protected override unsafe void OnCreateAnimation(Object p0)
//        {
//            if (id_onCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_ ==
//                IntPtr.Zero)
//                id_onCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_ =
//                    JNIEnv.GetMethodID(class_ref, "onCreateAnimation",
//                        "(Lcom/h6ah4i/android/widget/advrecyclerview/animator/impl/ItemAnimationInfo;)V");
//            var native_p0 = JNIEnv.ToLocalJniHandle(p0);
//            try
//            {
//                JValue* __args = stackalloc JValue[1];
//                __args[0] = new JValue(native_p0);
//                JNIEnv.CallVoidMethod(Handle,
//                    id_onCreateAnimation_Lcom_h6ah4i_android_widget_advrecyclerview_animator_impl_ItemAnimationInfo_,
//                    __args);
//            }
//            finally
//            {
//                JNIEnv.DeleteLocalRef(native_p0);
//            }
//        }
//    }
//}