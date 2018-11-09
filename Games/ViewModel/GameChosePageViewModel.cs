using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;

namespace Games.ViewModel
{
    public class GameChosePageViewModel : ViewModelBase
    {

        public ICommand OnClickButtons { set; get; }

        public GameChosePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            OnClickButtons = new DelegateCommand(OnClickButtonsCommandMethod);


        }

        private async void OnClickButtonsCommandMethod() {
            await NavigationService.NavigateAsync("ButtonsGamePage");
        }

    }
}
