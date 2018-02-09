using Prism.Commands;
using Prism.Navigation;

namespace BasePageDemo.NetStandard.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string Title => "Main page";

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("SecondPage")));

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}