using System;
using BasePageDemo.NetStandard.Controls;
using Prism.Commands;

namespace BasePageDemo.NetStandard.Services.Interfaces
{
    public interface IPopupService
    {
        void DisplayPopup(string title, string content, DelegateCommand<PopupResultEventArgs> command = null);
        bool Dismiss();
    }
}
