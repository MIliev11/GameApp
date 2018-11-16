using System;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Games.ViewModel.GamePageViewModels.ComponentsViewModels;
using Games.Model.ButtonsGame;
using Xamarin.Forms;
using Games.Extentions;
using System.Windows.Input;
using Prism.Services;
using System.Threading.Tasks;
using Prism.Events;

namespace Games.ViewModel.GamePageViewModels
{
    public class ButtonsGamePageViewModel : ViewModelBase
    {

        private long _startTime;

        private IPageDialogService _pageDialogService;

        public ButtonsGamePageViewModel(INavigationService navigation, IPageDialogService dialogService, IEventAggregator agregator) : base(navigation)
        {
            ItemsSource = new ObservableCollection<ButtonsHolderContentViewViewModel>
            {
                new ButtonsHolderContentViewViewModel(EButtonType.One, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.One, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.One, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.One, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Two, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Two, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Two, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Two, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Three, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Three, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Three, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Three, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Four, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Four, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Four, agregator),
                new ButtonsHolderContentViewViewModel(EButtonType.Four, agregator)
             };
            GameEndsCommand = new Command(OnGameEndsEvent);
            _startTime = DateTime.Now.Ticks;
            _pageDialogService = dialogService;
        }

        #region -- Public properties --


        private ObservableCollection<ButtonsHolderContentViewViewModel> _itemsSource = new ObservableCollection<ButtonsHolderContentViewViewModel>();
        public ObservableCollection<ButtonsHolderContentViewViewModel> ItemsSource
        {
            get
            {
                return _itemsSource;
            }
            set
            {
                SetProperty(ref _itemsSource, value.RandomizeListOrder());
            }
        }

        private ICommand _gameEndsCommand;
        public ICommand GameEndsCommand
        {
            get
            {
                return _gameEndsCommand;
            }
            set
            {
                SetProperty(ref _gameEndsCommand, value);
            }
        }

        #endregion

        #region -- Private helpers --

        private async void OnGameEndsEvent()
        {
            long passedTime = DateTime.Now.Ticks - _startTime;
            await Task.Delay(1000);
            await _pageDialogService.DisplayAlertAsync("Congrats!", String.Format("You scored {0} points!", passedTime), "Submit");
            await NavigationService.NavigateAsync("ScoreResultsPageViewModel");
        }

        #endregion

    }
}
