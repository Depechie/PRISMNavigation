using System;
using Prism.Commands;
using Prism.Events;
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

        private DelegateCommand _navigateSecondModalCommand;
        public DelegateCommand NavigateSecondModalCommand => _navigateSecondModalCommand ?? (_navigateSecondModalCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("SubPage", useModalNavigation: true)));

        public SubModalViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
        }
    }
}
