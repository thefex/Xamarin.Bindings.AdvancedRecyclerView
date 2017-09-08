using MvvmCross.Plugins.Messenger;

namespace XamarinMvvmCross_MeetupSample.Core
{
	public class ToastMvxMessage : MvxMessage
	{
		public ToastMvxMessage(object sender, string content) : base(sender)
		{
			Content = content;
		}

		public string Content { get; }
	}
}
