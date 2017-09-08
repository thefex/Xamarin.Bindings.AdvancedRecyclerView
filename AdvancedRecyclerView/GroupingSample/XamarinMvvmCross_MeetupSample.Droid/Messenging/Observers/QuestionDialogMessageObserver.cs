using System;
using Android.Support.V7.App;
using MvvmCross.Plugins.Messenger;
using XamarinMvvmCross_MeetupSample.Core;
using XamarinMvvmCross_MeetupSample.Core.MessageObserver;

namespace XamarinMvvmCross_MeetupSample.Droid
{

	internal class QuestionDialogMessageObserver : ActivityMessageObserver<QuestionDialogMvxMessage>
	{
		public QuestionDialogMessageObserver(WeakReference<AppCompatActivity> activityReference) : base(activityReference)
		{
		}

		protected override void OnMessageArrived(QuestionDialogMvxMessage messageToHandle)
		{
			var activityResponse = GetActivity();

			activityResponse.Handle(() =>
			{
				activityResponse.Results.ShowQuestionDialog(messageToHandle.Title, messageToHandle.Content, messageToHandle.OnYes, messageToHandle.OnNo);
			}, (error) => { });
		}
	}

}
