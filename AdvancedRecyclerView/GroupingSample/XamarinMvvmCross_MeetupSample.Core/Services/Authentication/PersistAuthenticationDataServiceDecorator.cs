using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using XamarinMvvmCross_MeetupSample.Core.Services.Authentication;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public class PersistAuthenticationDataServiceDecorator : IAuthenticationService
	{
		const string IsSignedInCacheKey = "IsSignedIn_CacheKey";

		readonly IAuthenticationService decoratedService;

		public PersistAuthenticationDataServiceDecorator(IAuthenticationService decoratedService)
		{
			this.decoratedService = decoratedService;
		}

		public async Task<bool> IsSignedIn()
		{
			bool isSignedIn = await
				BlobCache.LocalMachine
						.GetObject<bool>(IsSignedInCacheKey)
						.Catch(Observable.Return<bool>(false));

			if (!isSignedIn)
				return await decoratedService.IsSignedIn().ConfigureAwait(false);

			return isSignedIn;
		}

		public async Task<LayerResponse> SignIn(string userName, string password)
		{
			var signInResponse = await decoratedService.SignIn(userName, password).ConfigureAwait(false);

			if (signInResponse.IsSuccess)
				await BlobCache.LocalMachine.InsertObject(IsSignedInCacheKey, true);

			return signInResponse;
		}

		public async Task SignOut()
		{
			await BlobCache.LocalMachine.Invalidate(IsSignedInCacheKey);
			await decoratedService.SignOut().ConfigureAwait(false);
		}
	}
}
