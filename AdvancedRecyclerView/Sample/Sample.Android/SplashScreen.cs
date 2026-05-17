using Android.App;
using MvvmCross.Platforms.Android.Views;

namespace Sample.Android;

[Activity(
    NoHistory = true,
    MainLauncher = true,
    Theme = "@style/Theme.Splash")]
public class SplashScreen : MvxStartActivity
{
}
