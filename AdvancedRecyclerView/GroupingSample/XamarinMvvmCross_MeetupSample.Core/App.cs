using System.Threading.Tasks;
using Akavache;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using XamarinMvvmCross_MeetupSample.Core.Services.Authentication;
using XamarinMvvmCross_MeetupSample.Core.ViewModels;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public class App : MvvmCross.Core.ViewModels.MvxApplication
	{
		public override void Initialize()
		{
			BlobCache.ApplicationName = "Xamarines";
			BlobCache.EnsureInitialized();

			Mvx.RegisterSingleton<IAuthenticationService>(() =>
		   {
			   return new PersistAuthenticationDataServiceDecorator(new InMemoryAuthenticationService());
		   });
			                                         

			Mvx.RegisterType<LoginViewModel, LoginViewModel>();
			Mvx.RegisterType<MainViewModel, MainViewModel>();

		    Mvx.RegisterType<IMvxAppStart>(() =>
		    {
		        var authService = Mvx.Resolve<IAuthenticationService>();
				bool isSignedIn = false;
				Task.Run(async () =>
				{
					isSignedIn = await authService.IsSignedIn();
				}).Wait();
		        
		        if (isSignedIn)
		            return new MvxAppStart<MainViewModel>();

		        return new MvxAppStart<LoginViewModel>();
		    });

		}
	}
}
