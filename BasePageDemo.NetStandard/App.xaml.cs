using BasePageDemo.NetStandard.ViewModels;
using BasePageDemo.NetStandard.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace BasePageDemo
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MDPage/NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MDPage, MDViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            containerRegistry.RegisterForNavigation<SecondPage, SecondViewModel>();
            containerRegistry.RegisterForNavigation<SubPage, SubViewModel>();
            containerRegistry.RegisterForNavigation<SubModalPage, SubModalViewModel>();
        }
    }
}