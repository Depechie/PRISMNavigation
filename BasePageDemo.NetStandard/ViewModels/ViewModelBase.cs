using BasePageDemo.NetStandard.Models;
using BasePageDemo.NetStandard.PubSubEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace BasePageDemo.NetStandard.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        protected INavigationService _navigationService;
        protected IEventAggregator _eventAggregator;

        private PageMode _pageMode;
        public PageMode PageMode
        {
            get => _pageMode;
            set => SetProperty(ref _pageMode, value);
        }

        private bool _backButtonIsVisible;
        public bool BackButtonIsVisible
        {
            get => _backButtonIsVisible;
            set => SetProperty(ref _backButtonIsVisible, value);
        }

        private bool _isFabButtonVisible = false;
        public bool IsFabButtonVisible
        {
            get => _isFabButtonVisible;
            set => SetProperty(ref _isFabButtonVisible, value);
        }

        private DelegateCommand _navigateBackCommand;
        public DelegateCommand NavigateBackCommand
        {
            get => _navigateBackCommand ?? (_navigateBackCommand = new DelegateCommand(async () => await _navigationService.GoBackAsync()));
        }

        private DelegateCommand _hamburgerCommand;
        public DelegateCommand HamburgerCommand
        {
            get => _hamburgerCommand ?? (_hamburgerCommand = new DelegateCommand(() => _eventAggregator.GetEvent<HamburgerMenuEvent>().Publish()));
        }

        public ViewModelBase()
        {

        }

        public ViewModelBase(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
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

        protected virtual async void CloseAsync()
        {
            await _navigationService.GoBackAsync(useModalNavigation: PageMode == PageMode.Modal);
        }
    }
}