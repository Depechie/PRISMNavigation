using System;
using BasePageDemo.NetStandard.Services.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;

namespace BasePageDemo.NetStandard.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IPopupService _popupService;

        public string Title => "VIEW A";

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("SubPage")));

        private DelegateCommand _navigateModalCommand;
        public DelegateCommand NavigateModalCommand => _navigateModalCommand ?? (_navigateCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("NavigationPage/SubModalPage", useModalNavigation: true)));

        private DelegateCommand _popupCommand;
        public DelegateCommand PopupCommand => _popupCommand ?? (_popupCommand = new DelegateCommand(() => _popupService.DisplayPopup("", "", new DelegateCommand<Controls.PopupResultEventArgs>(async (result) =>
        {
            var t = result;
        }))));

        private DelegateCommand _fabCommand;
        public DelegateCommand FabCommand => _fabCommand ?? (_fabCommand = new DelegateCommand(() => IsFabButtonVisible = !IsFabButtonVisible));

        public MainViewModel(INavigationService navigationService, IPopupService popupService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)        {
            _popupService = popupService;
        }
    }
}