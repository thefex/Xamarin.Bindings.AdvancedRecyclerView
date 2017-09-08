using System;
using System.Threading.Tasks;
using XamarinMvvmCross_MeetupSample.Core.Services.Authentication;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public class InMemoryAuthenticationService : IAuthenticationService
	{
		bool isUserSignedIn;

		public InMemoryAuthenticationService()
		{
		}

		public Task<bool> IsSignedIn()
		{
			return Task.FromResult(isUserSignedIn);
		}

		public async Task<LayerResponse> SignIn(string userName, string password)
		{
			isUserSignedIn = userName.Equals("xamarin") && password.Equals("insanelab");

			/// SIMULATE REST SHOOT
			await Task.Delay(3500);

			var response = new LayerResponse();

			if (!isUserSignedIn)
				response.AddErrorMessage("You are not signed in!");

			return response;
		}

		public Task SignOut()
		{
			isUserSignedIn = false;
			return Task.FromResult(true);
		}
	}
}
