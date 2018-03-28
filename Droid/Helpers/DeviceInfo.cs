using System;
using BasePageDemo.Droid;
using BasePageDemo.NetStandard;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceInfo))]
namespace BasePageDemo.Droid
{
    public class DeviceInfo : IDeviceInfo
    {
        public float StatusbarHeight => 0;
    }
}