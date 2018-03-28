using System;
using BasePageDemo.iOS.Helpers;
using BasePageDemo.NetStandard;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceInfo))]
namespace BasePageDemo.iOS.Helpers
{
    public class DeviceInfo : IDeviceInfo
    {
        public float StatusbarHeight => (float)UIApplication.SharedApplication.StatusBarFrame.Size.Height;
    }
}