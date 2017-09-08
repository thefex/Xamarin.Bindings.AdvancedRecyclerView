using System;
using Android.Support.V7.App;
using MvvmCross.Plugins.Messenger;
using XamarinMvvmCross_MeetupSample.Core;
using XamarinMvvmCross_MeetupSample.Core.MessageObserver;

namespace XamarinMvvmCross_MeetupSample.Droid
{

	internal class MessageDialogObserver : ActivityMessageObserver<DialogMvxMessage>
	{
		public MessageDialogObserver(WeakReference<AppCompatActivity> activityReference) : base(activityReference)
		{
		}

		protected override void OnMessageArrived(DialogMvxMessage messageToHandle)
		{
			var activityResponse = GetActivity();

			activityResponse.Handle(() =>
			{
				activityResponse.Results.ShowMessageDialog(messageToHandle.Title, messageToHandle.Message, messageToHandle.ActionOnDismiss);
			}, (error) => { });
		}
	}

}
