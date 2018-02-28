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
            {
                //Full screen popup
                var cnt = ((ContentPage)((NavigationPage)current.Detail).CurrentPage).Content;
                if (cnt is Grid grd)
                {
                    grd.Children.Add(_popup, 0, 0);
                    Grid.SetRowSpan(_popup, 3);
                }

                //Full content popup
                //((BasePage)((NavigationPage)current.Detail).CurrentPage).BasePageContent.Add(_popup);
            }                
        }

        public bool Dismiss()
        {            
            return RemovePopup();
        }

        private void OnClicked(object sender, Controls.PopupResultEventArgs args)
        {
            RemovePopup();

            if (_command != null)
                _command.Execute(args);
        }

        private bool RemovePopup()
        {
            if (_popup != null && App.Current.MainPage is MasterDetailPage current)
            {
                //Full page popup
                var cnt = ((ContentPage)((NavigationPage)current.Detail).CurrentPage).Content;
                if (cnt is Grid grd)
                    grd.Children.Remove(_popup);

                //Full content popup
                //((BasePage)((NavigationPage)current.Detail).CurrentPage).BasePageContent.Remove(_popup);

                _popup.Click -= OnClicked;
                _popup = null;

                return true;
            }

            return false;
        }
    }
}