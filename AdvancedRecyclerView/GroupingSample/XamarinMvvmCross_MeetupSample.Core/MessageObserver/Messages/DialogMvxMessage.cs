using System;
using MvvmCross.Plugins.Messenger;

namespace XamarinMvvmCross_MeetupSample.Core
{

	public class DialogMvxMessage : MvxMessage
	{
		public DialogMvxMessage(object sender) : base(sender)
		{
		}
		public string Title { get; set; }
		public string Message { get; set; }
		public string ButtonOkCaption { get; set; }
		public Action ActionOnDismiss { get; set; } = () => { };
	}

	
}