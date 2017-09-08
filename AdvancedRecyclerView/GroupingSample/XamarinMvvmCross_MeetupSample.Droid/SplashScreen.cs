using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using MvvmCross.Droid.Views;

namespace XamarinMvvmCross_MeetupSample.Droid
{
	[Activity(
		Label = "XamarinMvvmCross_MeetupSample.Droid"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen : MvxSplashScreenActivity
	{
		public SplashScreen()
			: base(Resource.Layout.SplashScreen)
		{
		}
	}
}
