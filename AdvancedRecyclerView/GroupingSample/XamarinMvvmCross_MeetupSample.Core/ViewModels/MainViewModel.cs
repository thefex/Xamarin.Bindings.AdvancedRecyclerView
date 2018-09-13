using MvvmCross.Commands;
using XamarinMvvmCross_MeetupSample.Core.Services.Authentication;

namespace XamarinMvvmCross_MeetupSample.Core.ViewModels
{
	public class MainViewModel : BaseMvxViewModel
	{
		readonly IAuthenticationService authService;

		public MainViewModel(IAuthenticationService authService)
		{
			this.authService = authService;
		}

		public MvxCommand LogoutCommand => new LogoutCommandBuilder(this, authService).BuildCommand();
	}
}
