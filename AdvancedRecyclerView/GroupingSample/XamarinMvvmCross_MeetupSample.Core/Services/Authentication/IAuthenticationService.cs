using System.Threading.Tasks;

namespace XamarinMvvmCross_MeetupSample.Core.Services.Authentication
{
    public interface IAuthenticationService
    {
		Task<LayerResponse> SignIn(string userName, string password);

		Task SignOut();

        Task<bool> IsSignedIn();
    }
}