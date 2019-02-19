using System;
using Akavache;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using XamarinMvvmCross_MeetupSample.Core;

namespace XamarinMvvmCross_MeetupSample.Droid
{
	//You can specify additional application information in this attribute
#if DEBUG
	[Application(Debuggable = true)]
#else
	[Application(Debuggable = false)]
#endif
    public class MainApplication : MvxAndroidApplication
    {
		public MainApplication(IntPtr handle, JniHandleOwnership transer)
		  : base(handle, transer)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();
			//A great place to initialize Xamarin.Insights and Dependency Services!
		}

		public override void OnTerminate()
		{
			base.OnTerminate();
			BlobCache.Shutdown().Wait();
		}

	}
}