using System;
using MvvmCross.Plugin.Messenger;

namespace XamarinMvvmCross_MeetupSample.Core
{

	public class QuestionDialogMvxMessage : MvxMessage
	{
		public string Title { get; }
		public string Content { get; }

		public QuestionDialogMvxMessage(string title, string content, object sender) : base(sender)
		{
			Title = title;
			Content = content;
		}

		public Action OnYes { get; set; }

		public Action OnNo { get; set; }
	}
}