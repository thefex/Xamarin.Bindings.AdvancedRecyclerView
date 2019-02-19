using System.Threading.Tasks;
using Akavache;
using MvvmCross;
using MvvmCross.ViewModels;
using XamarinMvvmCross_MeetupSample.Core.Services.Authentication;
using XamarinMvvmCross_MeetupSample.Core.ViewModels;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
            base.Initialize();
			BlobCache.ApplicationName = "Xamarines";
			BlobCache.EnsureInitialized();

			Mvx.RegisterSingleton<IAuthenticationService>(() =>
		   {
			   return new PersistAuthenticationDataServiceDecorator(new InMemoryAuthenticationService());
		   });
            Mvx.RegisterSingleton<ExceptionGuardService>(() => new ExceptionGuardService(new SampleBasedExceptionGuard()));
			                                         

			Mvx.RegisterType<LoginViewModel, LoginViewModel>();
			Mvx.RegisterType<MainViewModel, MainViewModel>();
			var authService = Mvx.Resolve<IAuthenticationService>();
			
			bool isSignedIn = false;
            /*Task.Run(async () =>
            {
                isSignedIn = await authService.IsSignedIn();

                if (isSignedIn)
                    RegisterAppStart<MainViewModel>();
                else
                    RegisterAppStart<LoginViewModel>();
            });*/
            RegisterAppStart<LoginViewModel>();
		}
	}
}
