using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Sample.Core.ViewModels;

public class MainViewModel : MvxViewModel
{
    private readonly IMvxNavigationService _navigationService;

    public MainViewModel(IMvxNavigationService navigationService)
    {
        _navigationService = navigationService;
        NavigateToSimpleListCommand = new MvxAsyncCommand(
            () => _navigationService.Navigate<SimpleListViewModel>());
        NavigateToExpandableListCommand = new MvxAsyncCommand(
            () => _navigationService.Navigate<ExpandableListViewModel>());
    }

    public IMvxAsyncCommand NavigateToSimpleListCommand { get; }
    public IMvxAsyncCommand NavigateToExpandableListCommand { get; }
}
