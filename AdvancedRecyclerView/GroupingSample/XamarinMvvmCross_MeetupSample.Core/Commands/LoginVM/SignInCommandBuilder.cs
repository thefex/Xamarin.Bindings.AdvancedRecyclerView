using System;
using XamarinMvvmCross_MeetupSample.Core.Services;
using XamarinMvvmCross_MeetupSample.Core.Services.Authentication;
using XamarinMvvmCross_MeetupSample.Core.ViewModels;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public class SignInCommandBuilder : MvxAsyncGuardedCommandBuilder
	{
		readonly IAuthenticationService authenticationService;
		readonly LoginViewModel loginViewModel;

		public SignInCommandBuilder(IAuthenticationService authenticationService, LoginViewModel loginViewModel)
		{
			this.loginViewModel = loginViewModel;
			this.authenticationService = authenticationService;
		}

		protected override async System.Threading.Tasks.Task ExecuteCommandAction()
		{
			var authResponse = await authenticationService.SignIn(loginViewModel.Username, loginViewModel.Password);

			EnqueueAfterCommandExecuted(() =>
			{
				authResponse.Handle(() =>
				{
					loginViewModel.NavigateTo<MainViewModel>();
				}, errorMsg =>
				{
					ServicesLocation.Messenger.Publish(new DialogMvxMessage(this)
					{ 
						Title = "Can't sign in!",
						Message = errorMsg
					});
				});
			});			
		}

	}
}
