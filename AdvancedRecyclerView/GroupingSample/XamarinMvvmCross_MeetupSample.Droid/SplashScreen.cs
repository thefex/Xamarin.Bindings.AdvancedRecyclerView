using System;
using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;
using XamarinMvvmCross_MeetupSample.Core;

namespace XamarinMvvmCross_MeetupSample.Droid
{
	[Activity(
		Label = "XamarinMvvmCross_MeetupSample.Droid"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity<Setup, App>
	{
		public SplashScreen()
			: base(Resource.Layout.SplashScreen)
		{
		}
	}
}
