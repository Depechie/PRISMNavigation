using Prism.Commands;
using Prism.Navigation;

namespace BasePageDemo.NetStandard.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string Title => "VIEW A";

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("SubPage")));

        private DelegateCommand _navigateModalCommand;
        public DelegateCommand NavigateModalCommand => _navigateModalCommand ?? (_navigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("NavigationPage/SubModalPage", useModalNavigation: true)));

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}