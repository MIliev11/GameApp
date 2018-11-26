using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;

namespace Games.ViewModel
{
    public class GameChosePageViewModel : ViewModelBase
    {

        public GameChosePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            OnClickButtons = new DelegateCommand(OnClickButtonsCommandMethod);
            Title = "Choose game";
        }

        #region -- Public properties --

        private ICommand _onClickButtons;
        public ICommand OnClickButtons
        {
            get => _onClickButtons;
            set => SetProperty(ref _onClickButtons, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        #endregion

        #region -- Private helpers --

        private async void OnClickButtonsCommandMethod()
        {
            await NavigationService.NavigateAsync(new Uri("http://www.Games/NavigationPage/ButtonsGamePage", UriKind.Absolute));
        }

        #endregion

    }
}
