using System;
using BasePageDemo.NetStandard.Controls;
using BasePageDemo.NetStandard.Services.Interfaces;
using BasePageDemo.NetStandard.Views;
using Prism.Commands;
using Xamarin.Forms;

namespace BasePageDemo.NetStandard.Services
{
    public class PopupService : IPopupService
    {
        private DelegateCommand<PopupResultEventArgs> _command;
        private Popup _popup;

        /// <summary>
        /// Display the popup
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="content">Content.</param>
        /// <param name="command">Command.</param>
        public void DisplayPopup(string title, string content, DelegateCommand<PopupResultEventArgs> command = null)
        {
            _command = command;
            _popup = new Popup();

            _popup.Click += OnClicked;

            if(App.Current.MainPage is MasterDetailPage current)
                ((BasePage)((NavigationPage)current.Detail).CurrentPage).BasePageContent.Add(_popup);
        }

        private void OnClicked(object sender, Controls.PopupResultEventArgs args)
        {
            if (App.Current.MainPage is MasterDetailPage current)
                ((BasePage)((NavigationPage)current.Detail).CurrentPage).BasePageContent.Remove(_popup);

            if (_command != null)
                _command.Execute(args);
        }
    }
}