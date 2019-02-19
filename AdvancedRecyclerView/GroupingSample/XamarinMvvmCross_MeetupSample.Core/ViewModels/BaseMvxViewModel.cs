using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
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
		    Mvx.Resolve<IMvxNavigationService>().Navigate<TViewModel>();
		}

		public virtual Task Load()
		{
			return Task.FromResult(true);
		}

        public override void ViewAppeared()
        {
            _messageObserversController.StartObserving();
            base.ViewAppeared();
        }

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
            _messageObserversController.StopObserving();
        }

    }
}