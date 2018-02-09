using System;
using System.Collections.Generic;
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
        #endregion

        public IList<View> BasePageContent { get => BaseContent.Children; }

        public BasePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //TODO: Glenn - make the status row height depending from the platform ( Android or iOS ) and device ( iOS regular or iPhone X )
            StatusRowDefinition.Height = 20;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var t = Navigation.NavigationStack;
        }
    }
}