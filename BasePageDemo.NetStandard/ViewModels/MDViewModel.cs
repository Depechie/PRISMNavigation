using System;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace BasePageDemo.NetStandard.ViewModels
{
    public class MDViewModel : ViewModelBase
    {
        private DelegateCommand _navigateVACommand;
        public DelegateCommand NavigateVACommand => _navigateVACommand ?? (_navigateVACommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("MainPage")));

        private DelegateCommand _navigateVBCommand;
        public DelegateCommand NavigateVBCommand => _navigateVBCommand ?? (_navigateVBCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("SecondPage")));

        public MDViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}

