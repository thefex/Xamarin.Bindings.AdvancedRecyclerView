using Android.Content;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;
using Sample.ViewModels;

namespace Sample
{
    public class Setup : MvxAndroidSetup
    {
        public Setup() : base()
        {
        }

        

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        class App : MvxApplication
        {
            public override void Initialize()
            {
                base.Initialize();
                
                
                Mvx.RegisterType<SwipeExampleViewModel, SwipeExampleViewModel>();
                Mvx.RegisterType<MainViewModel, MainViewModel>();

                RegisterAppStart<MainViewModel>();
            }
        }
    }
}