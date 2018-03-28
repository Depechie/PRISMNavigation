using System;
using System.Collections.Generic;
using BasePageDemo.NetStandard.Models;
using BasePageDemo.NetStandard.PubSubEvents;
using BasePageDemo.NetStandard.Services.Interfaces;
using BasePageDemo.NetStandard.ViewModels;
using Prism.Events;
using Prism.Unity;
using Unity;
using Xamarin.Forms;

namespace BasePageDemo.NetStandard.Views
{
    public partial class BasePage : ContentPage
    {
        #region Bindable properties
        public static readonly BindableProperty BasePageTitleProperty = BindableProperty.Create(nameof(BasePageTitle), typeof(string), typeof(BasePage), string.Empty, defaultBindingMode: BindingMode.OneWay, propertyChanged: BasePageTitleChanged);

        public string BasePageTitle
        {
            get => (string)GetValue(BasePageTitleProperty);
            set => SetValue(BasePageTitleProperty, value);
        }

        private static void BasePageTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable != null && bindable is BasePage basePage)
                basePage.PageTitle.Text = (string)newValue;
        }

        public static readonly BindableProperty PageModeProperty = BindableProperty.Create(nameof(PageMode), typeof(PageMode), typeof(BasePage), PageMode.None, propertyChanged: OnPageModePropertyChanged);

        public PageMode PageMode
        {
            get => (PageMode)GetValue(PageModeProperty);
            set => SetValue(PageModeProperty, value);
        }

        private static void OnPageModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            BasePage page = (BasePage)bindable;
            page.SetPageMode((PageMode)newValue);
        }
        #endregion

        protected IUnityContainer Container { get; private set; }

        protected IEventAggregator EventAggregator { get; private set; }

        public IList<View> BasePageContent { get => BaseContent.Children; }
        public IPopupService PopupService { get; }

        public BasePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            SetPageMode(PageMode.None);

            PopupService = ((PrismApplication)App.Current).Container.GetContainer().Resolve<IPopupService>();

            StatusRowDefinition.Height = DependencyService.Get<IDeviceInfo>().StatusbarHeight;

            Container = ((PrismApplication)App.Current).Container.GetContainer();
            EventAggregator = Container.Resolve<IEventAggregator>();
            EventAggregator.GetEvent<HamburgerMenuEvent>().Subscribe(HandleHamburgerMenu);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ViewModelBase)BindingContext).PageMode = PageMode;
        }

        protected override bool OnBackButtonPressed()
        {
            return PopupService.Dismiss();
        }

        private void HandleHamburgerMenu()
        {
            ((MasterDetailPage)Application.Current.MainPage).IsPresented = true;
        }

        private void SetPageMode(PageMode pageMode)
        {
            ((ViewModelBase)BindingContext).PageMode = pageMode;
            switch (pageMode)
            {
                case PageMode.Menu:
                    PageHamburgerButton.IsVisible = true;
                    PageCloseButton.IsVisible = false;
                    PageBackButton.IsVisible = false;
                    break;
                case PageMode.Navigate:
                    PageHamburgerButton.IsVisible = false;
                    PageCloseButton.IsVisible = false;
                    PageBackButton.IsVisible = true;
                    break;
                case PageMode.Modal:
                    PageCloseButton.IsVisible = true;
                    PageHamburgerButton.IsVisible = false;
                    PageBackButton.IsVisible = false;
                    break;
                default:
                    PageCloseButton.IsVisible = false;
                    PageHamburgerButton.IsVisible = false;
                    PageBackButton.IsVisible = false;
                    break;
            }
        }
    }
}