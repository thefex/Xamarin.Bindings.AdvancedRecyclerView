using System;
using System.Threading.Tasks;
using XamarinMvvmCross_MeetupSample.Core.Services;
using XamarinMvvmCross_MeetupSample.Core.Services.Authentication;
using XamarinMvvmCross_MeetupSample.Core.ViewModels;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public class LogoutCommandBuilder : MvxAsyncGuardedCommandBuilder
	{
		readonly MainViewModel mainViewModel;
		readonly IAuthenticationService authService;

		public LogoutCommandBuilder(MainViewModel mainViewModel, IAuthenticationService authService)
		{
			this.authService = authService;
			this.mainViewModel = mainViewModel;
		}

		protected override async Task ExecuteCommandAction()
		{
			TaskCompletionSource<bool> shouldLogoutAwaiter = new TaskCompletionSource<bool>();

			ServicesLocation.Messenger.Publish(
				new QuestionDialogMvxMessage("Logout", "Would you like to logout?", this)
				{
					OnNo = () => shouldLogoutAwaiter.SetResult(false),
					OnYes = () => shouldLogoutAwaiter.SetResult(true)
				}
			);

			bool shouldLogout = await shouldLogoutAwaiter.Task;

			if (!shouldLogout)
				return;

			await authService.SignOut();
			EnqueueAfterCommandExecuted(() =>
			{
				mainViewModel.NavigateTo<LoginViewModel>();
			});
		}
	}
}
