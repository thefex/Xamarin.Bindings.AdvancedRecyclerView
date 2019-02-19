using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;
using RecordGuard.ListSample.App;

namespace RecordGuard.ListSample.Android
{
    [Activity(MainLauncher = true
        , Icon = "@drawable/appIcon"
        , Theme = "@style/splashTheme"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity<Setup, AppSetup>
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}