using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public class LayerResponse
	{
		private bool _forceFailedResponse;

		public LayerResponse()
		{
			ErrorMessages = new List<string>();
		}

		[JsonIgnore]
		public bool IsSuccess => !ErrorMessages.Any() && !_forceFailedResponse;

		[JsonProperty("errorMessages")]
		public IList<string> ErrorMessages { get; set; }

		[JsonIgnore]
		public string FormattedErrorMessages => ErrorMessages.Any()
			? ErrorMessages.Aggregate((prev, current) => prev + Environment.NewLine + current)
			: string.Empty;


		public LayerResponse AddErrorMessage(string errorMsg)
		{
			ErrorMessages.Add(errorMsg);
			return this;
		}

		public LayerResponse SetAsFailureResponse()
		{
			_forceFailedResponse = true;
			return this;
		}
	}

	public sealed class LayerResponse<TResult> : LayerResponse
	{
		public LayerResponse(TResult results)
		{
			Results = results;
		}

		public LayerResponse()
		{
		}

		public TResult Results { get; }

		public new LayerResponse<TResult> AddErrorMessage(string errorMsg)
		{
			base.AddErrorMessage(errorMsg);
			return this;
		}

		public new LayerResponse<TResult> SetAsFailureResponse()
		{
			base.SetAsFailureResponse();
			return this;
		}
	}
}
