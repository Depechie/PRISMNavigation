using System;
using Prism.Commands;
using Prism.Navigation;

namespace BasePageDemo.NetStandard.ViewModels
{
    public class SubModalViewModel : ViewModelBase
    {
        public string Title => "SUB MODAL";

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(async () => await _navigationService.GoBackAsync(useModalNavigation: true)));

        private DelegateCommand _navigateSubCommand;
        public DelegateCommand NavigateSubCommand => _navigateSubCommand ?? (_navigateSubCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("SubPage")));

        public SubModalViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
