using System;
using MvvmCross;
using MvvmCross.ViewModels;
using RecordGuard.ListSample.ViewModel;

namespace RecordGuard.ListSample
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            
            Mvx.IoCProvider.RegisterType<MainViewModel, MainViewModel>();
            RegisterAppStart<MainViewModel>();
        }
    }
}