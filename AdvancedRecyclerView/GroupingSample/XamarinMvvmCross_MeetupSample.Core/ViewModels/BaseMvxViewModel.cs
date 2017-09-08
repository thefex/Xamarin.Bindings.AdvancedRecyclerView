using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using XamarinMvvmCross_MeetupSample.Core.MessageObserver;
using XamarinMvvmCross_MeetupSample.Core.Services;

namespace XamarinMvvmCross_MeetupSample.Core.ViewModels
{
    public class BaseMvxViewModel : MvxViewModel
    {
        private readonly MessageObserversController _messageObserversController;

        public BaseMvxViewModel()
        {
            _messageObserversController = new MessageObserversController(ServicesLocation.Messenger);
        }

		public void NavigateTo<TViewModel>() where TViewModel : IMvxViewModel
		{
			ShowViewModel<TViewModel>();
		}

		public virtual Task Load()
		{
			return Task.FromResult(true);
		}

		public override void Appearing()
		{
			_messageObserversController.StartObserving();
			base.Appearing();
		}

		public override void Disappearing()
		{
			_messageObserversController.StopObserving();
			base.Disappearing();
		}
    }
}