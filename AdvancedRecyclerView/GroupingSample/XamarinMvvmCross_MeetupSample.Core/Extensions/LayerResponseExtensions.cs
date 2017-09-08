using System;
using System.Threading.Tasks;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public static class LayerResponseExtensions
	{
		public static void Handle(this LayerResponse response, Action onSuccess, Action<string> onFailure)
		{
			if (response.IsSuccess)
				onSuccess();
			else
				onFailure(response.FormattedErrorMessages);
		}

		public static LayerResponse CloneFailedResponse(this LayerResponse response)
		{
			var clonedResponse = new LayerResponse();

			foreach (var error in response.ErrorMessages)
				clonedResponse.AddErrorMessage(error);

			return clonedResponse;
		}

		public static LayerResponse<TResult> CloneFailedResponse<TResult>(this LayerResponse response)
		{
			if (response.IsSuccess)
				throw new InvalidOperationException("Provided response finished with success.");

			var clonedResponse = new LayerResponse<TResult>();

			foreach (var error in response.ErrorMessages)
				clonedResponse.AddErrorMessage(error);

			return clonedResponse;
		}
	}
}
