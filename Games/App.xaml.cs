using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;
using Prism.Unity;
using Prism.Ioc;
using Games.View;
using Games.ViewModel;
using Games.ViewModel.GamePageViewModels;
using Games.View.GamePages;
using Prism.Events;
using Games.Events;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Games
{
    public partial class App : PrismApplication
    {

        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/GamePageButtons");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<GamePageButtons, ButtonsGamePageViewModel>();

            containerRegistry.RegisterForNavigation<RegistrationPage, RegistrationPageViewModel>();
            containerRegistry.RegisterForNavigation<GameChosePage, GameChosePageViewModel>();
            containerRegistry.RegisterForNavigation<ScoreResultsPage, ScoreResultsPageViewModel>();
        }

    }
}
