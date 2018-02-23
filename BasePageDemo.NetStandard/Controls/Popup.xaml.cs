﻿using System;
using Xamarin.Forms;

namespace BasePageDemo.NetStandard.Controls
{
    public enum PopupResult
    {
        Ok,
        Cancel,
        Yes,
        No
    }

    public class PopupResultEventArgs : EventArgs
    {
        public PopupResult Result { get; set; }
    }

    public delegate void PopupResultEventHandler(object sender, PopupResultEventArgs e);

    public partial class Popup : ContentView
    {
        public event PopupResultEventHandler Click;

        public Popup()
        {
            InitializeComponent();
        }

        private void OnOkClicked(object sender, System.EventArgs e)
        {
            Click?.Invoke(this, new PopupResultEventArgs() { Result = PopupResult.Ok });
        }
    }
}