using System;
using Prism.Commands;
using Prism.Navigation;

namespace BasePageDemo.NetStandard.ViewModels
{
    public class SubViewModel : ViewModelBase
    {
        public string Title => "SUB";

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(async () => await _navigationService.GoBackAsync()));

        public SubViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
