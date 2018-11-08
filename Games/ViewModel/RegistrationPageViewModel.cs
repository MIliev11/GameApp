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

        public ICommand OnStartPressedCommand { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private UserManager UserManager;

        IPageDialogService PageDialog;

        public RegistrationPageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService)
        {
            PageDialog = pageDialog;
            UserManager = new UserManager();
            OnStartPressedCommand = new DelegateCommand(() => OnStarted());
        }

        private async void OnStarted()
        {
            if(CanUseUsername())
            {
                UserManager.AddUser(new User(Username));
                await NavigationService.NavigateAsync(new Uri("http://www.Games/GameChosePage", UriKind.Absolute));
            }
            else
                await PageDialog?.DisplayAlertAsync("Username", "Use another username to continue", "OK");
        }

        private bool CanUseUsername() {
            if(Username != "" && Username != null)
                return !UserManager.Exist(new User(Username));
            Username = UserManager.GetDefaultUsername();
            return !UserManager.Exist(new User(Username));
        }
    }
}
