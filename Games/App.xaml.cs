using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;
using Prism.Unity;
using Prism.Ioc;
using Games.ViewModel;
using Prism.Events;
using Games.View;
using Prism.Navigation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Games
{
    public partial class App : PrismApplication
    {

        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        { }

        #region -- Overrides --

        protected override async void OnInitialized()
        {
            InitializeComponent();

            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("player", "King");
            await NavigationService.NavigateAsync("NavigationPage/ButtonsGamePage", parameters);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<ButtonsGamePage, ButtonsGamePageViewModel>();
        }

        #endregion

    }
}
