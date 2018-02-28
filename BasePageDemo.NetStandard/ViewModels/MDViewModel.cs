using System;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Xamarin.Forms;

namespace BasePageDemo.NetStandard.ViewModels
{
    public class MDViewModel : ViewModelBase
    {
        private DelegateCommand _navigateVACommand;
        public DelegateCommand NavigateVACommand => _navigateVACommand ?? (_navigateVACommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("NavigationPage/MainPage")));

        private DelegateCommand _navigateVBCommand;
        public DelegateCommand NavigateVBCommand => _navigateVBCommand ?? (_navigateVBCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("NavigationPage/SecondPage")));

        public MDViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {

        }
    }
}

