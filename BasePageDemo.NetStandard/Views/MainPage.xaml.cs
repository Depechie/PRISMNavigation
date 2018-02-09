using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BasePageDemo.NetStandard.Views
{
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnMenuClicked(object sender, System.EventArgs e)
        {
            ((MasterDetailPage)Application.Current.MainPage).IsPresented = true;
        }
    }
}