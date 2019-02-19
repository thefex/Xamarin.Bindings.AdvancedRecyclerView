using MvvmCross;
using MvvmCross.ViewModels;
using RecordGuard.ListSample.App.ViewModel;

namespace RecordGuard.ListSample.App
{
    public class AppSetup : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            
            Mvx.IoCProvider.RegisterType<MainViewModel, MainViewModel>();
            RegisterAppStart<MainViewModel>();
        }
    }
}