using System;
using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Shared.Presenter;
using XamarinMvvmCross_MeetupSample.Core.ViewModels;

namespace XamarinMvvmCross_MeetupSample.Droid
{
	public class ApplicationPresenter : MvxFragmentsPresenter
	{
		public ApplicationPresenter(IEnumerable<Assembly> androidViewAssemblies) : base(androidViewAssemblies)
		{
		}

		protected override Intent CreateIntentForRequest(MvxViewModelRequest request)
		{
			var intent = base.CreateIntentForRequest(request);

			if (Activity.GetType() == typeof(SplashScreen))
				intent.AddFlags(ActivityFlags.NoAnimation);

			if (request.ViewModelType == typeof(MainViewModel) ||
				request.ViewModelType == typeof(LoginViewModel))
				intent.AddFlags(ActivityFlags.ClearTask);

			return intent;
		}
	}
}
