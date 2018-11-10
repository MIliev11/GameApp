using System;
using System.Windows.Input;
using Games.Model;
using Games.Model.Data;
using Games.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Games.ViewModel
{
    public class RegistrationPageViewModel : ViewModelBase
    {

        private IPageDialogService _pageDialog;

        private UserManager _userManager;

        public RegistrationPageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService)
        {
            _pageDialog = pageDialog;
            _userManager = new UserManager();
            OnStartPressedCommand = new DelegateCommand(() => OnStarted());
            Username = _userManager.GetDefaultUsername();
        }

        #region -- Public properties --

        public ICommand OnStartPressedCommand { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        #endregion

        #region -- Private helpers --

        private async void OnStarted()
        {
            if (CanUseUsername())
            {
                _userManager.AddUser(new User(Username));
                await NavigationService.NavigateAsync(new Uri("http://www.Games/GameChosePage", UriKind.Absolute));
            }
            else
                await _pageDialog.DisplayAlertAsync("Username", "Use another username to continue", "OK");
        }

        private bool CanUseUsername()
        {
            if (Username != "" && Username != null)
                return !_userManager.Exist(new User(Username));
            return false;
        }

        #endregion

    }
}
