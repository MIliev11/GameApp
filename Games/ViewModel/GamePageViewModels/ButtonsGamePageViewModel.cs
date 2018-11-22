using System;
using Prism.Navigation;
using Games.ViewModel.GamePageViewModels.ComponentsViewModels;
using Games.Model.ButtonsGame;
using Games.Extentions;
using Prism.Services;
using System.Threading.Tasks;
using Prism.Events;
using Games.Events;
using System.Collections.Generic;

namespace Games.ViewModel.GamePageViewModels
{
    public class ButtonsGamePageViewModel : ViewModelBase
    {
        private string _userName;

        private long _startedTime;

        private IEventAggregator _eventAgregator;

        private IPageDialogService _dialogService;

        public ButtonsGamePageViewModel(INavigationService navigation, IPageDialogService dialogService, IEventAggregator agregator) : base(navigation)
        {
            _eventAgregator = agregator;
            _dialogService = dialogService;
            ItemsSource = new List<ButtonsHolderContentViewViewModel>
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
            _startedTime = DateTime.Now.Ticks;
            agregator.GetEvent<ButtonPressedEvent>().Subscribe(OnAnyButtonPressed);
            agregator.GetEvent<GameEndsEvent>().Subscribe(OnGameEnds);
        }

        #region -- Public properties --

        private List<ButtonsHolderContentViewViewModel> _itemsSource = new List<ButtonsHolderContentViewViewModel>();
        public List<ButtonsHolderContentViewViewModel> ItemsSource
        {
            get => _itemsSource;
            set => SetProperty(ref _itemsSource, value.RandomizeListOrder());
        }

        #endregion

        #region -- Overrides --

        public new void OnNavigatedTo(INavigationParameters parameters)
        {
            _userName = parameters.GetValue<string>("Player");
        }

        #endregion

        #region -- Private helpers --

        private void OnAnyButtonPressed(EButtonType type)
        {
            EButtonType collected = ItemsSource.CollectedButtons();
            int Count = ItemsSource.GetNumberOfSelectedButton();

            if (ItemsSource.IsAnotherSelected(type))
                ItemsSource.UnselectAll();
            if (Count == 4)
                ItemsSource.ReorderByType(collected);

            RaisePropertyChanged(nameof(ItemsSource));

            if (ItemsSource.IsAllOrdered())
                _eventAgregator.GetEvent<GameEndsEvent>().Publish();
        }

        private async void OnGameEnds()
        {
            long passedTime = DateTime.Now.Ticks;
            TimeSpan timeSpan = TimeSpan.FromTicks(passedTime - _startedTime);
            await Task.Delay(1000);
            await _dialogService.DisplayAlertAsync("Congrats!", String.Format("You passed in {0} min {1} sec {2} ms!", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds), "Submit");
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("Game", "Buttons");
            parameters.Add("Player", _userName);
            parameters.Add("Score", passedTime);
            await NavigationService.NavigateAsync(new System.Uri("https://Games.com/NavigationPage/GameChosePage/ScoreResultsPage", UriKind.Absolute), parameters);
        }


        #endregion
    }
}
