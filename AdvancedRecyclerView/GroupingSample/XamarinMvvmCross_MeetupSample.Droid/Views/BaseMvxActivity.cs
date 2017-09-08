using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Runtime;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using XamarinMvvmCross_MeetupSample.Core;
using XamarinMvvmCross_MeetupSample.Core.MessageObserver;
using XamarinMvvmCross_MeetupSample.Core.Services;
using XamarinMvvmCross_MeetupSample.Core.ViewModels;

namespace XamarinMvvmCross_MeetupSample.Droid.Views
{
	public abstract class BaseMvxActivity<TViewModel> : MvxCachingFragmentCompatActivity<TViewModel> where TViewModel : class, IMvxViewModel
	{
		private MessageObserversController _messageObserversController;

		protected BaseMvxActivity()
		{
		}

		protected BaseMvxActivity(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(LayoutResource);

			_messageObserversController = new MessageObserversController(ServicesLocation.Messenger)
				.AddObservers(GetMessageObservers());
			
			_messageObserversController.StartObserving();

			if (ViewModel is BaseMvxViewModel)
				(ViewModel as BaseMvxViewModel).Load();
 
		}

		protected virtual IEnumerable<IMessageObserver> GetMessageObservers()
		{
			yield return new QuestionDialogMessageObserver(new WeakReference<Android.Support.V7.App.AppCompatActivity>(this));
			yield return new MessageDialogObserver(new WeakReference<Android.Support.V7.App.AppCompatActivity>(this));
		}

		protected override void OnResume()
		{
			_messageObserversController.StartObserving();
			base.OnResume();
		}

		protected override void OnPause()
		{
			base.OnPause();
			_messageObserversController.StopObserving();
		}

		protected abstract int LayoutResource { get; }
	}
}
