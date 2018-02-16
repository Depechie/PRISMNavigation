using Prism.Commands;
using Prism.Navigation;

namespace BasePageDemo.NetStandard.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        public string Title => "VIEW B";

        private DelegateCommand _navigateSubCommand;
        public DelegateCommand NavigateSubCommand => _navigateSubCommand ?? (_navigateSubCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("SubPage")));

        public SecondViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}