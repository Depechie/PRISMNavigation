using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace BasePageDemo.NetStandard.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        public INavigationService _navigationService;

        private bool _backButtonIsVisible;
        public bool BackButtonIsVisible
        {
            get => _backButtonIsVisible;
            set => SetProperty(ref _backButtonIsVisible, value);
        }

        private DelegateCommand _navigateBackCommand;
        public DelegateCommand NavigateBackCommand
        {
            get => _navigateBackCommand ?? (_navigateBackCommand = new DelegateCommand(async () => await _navigationService.GoBackAsync()));
        }

        public ViewModelBase()
        {

        }

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //if (Application.Current.MainPage != null)
            //{
            //    BackButtonIsVisible = ((NavigationPage)Application.Current.MainPage).Navigation.NavigationStack.Count > 1;
            //}
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}