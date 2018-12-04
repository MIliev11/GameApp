using System;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Games.ControllsViewModels;
using System.Windows.Input;
using Xamarin.Forms;
using Games.Model;
using Games.Extentions;
using System.Threading.Tasks;
using Prism.Services;

namespace Games.ViewModel
{
    public class ButtonsGamePageViewModel : ViewModelBase
    {

        #region -- Private Fields --

        private ICommand _onButtonClickCommand;

        private int _currentSortedPosition;

        private long _startTimeStamp;

        private string _player;

        private IPageDialogService _pageDialogService;

        #endregion

        public ButtonsGamePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            _onButtonClickCommand = new Command(OnButtonClickCommandHandler);
            _startTimeStamp = DateTime.Now.Ticks;
            _pageDialogService = pageDialogService;
            ItemSource = new ObservableCollection<SelectedButtonViewModel>
            {
                new SelectedButtonViewModel(EButtonType.ONE, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.ONE, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.ONE, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.ONE, _onButtonClickCommand),

                new SelectedButtonViewModel(EButtonType.TWO, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.TWO, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.TWO, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.TWO, _onButtonClickCommand),

                new SelectedButtonViewModel(EButtonType.THREE, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.THREE, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.THREE, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.THREE, _onButtonClickCommand),

                new SelectedButtonViewModel(EButtonType.FOUR, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.FOUR, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.FOUR, _onButtonClickCommand),
                new SelectedButtonViewModel(EButtonType.FOUR, _onButtonClickCommand)
            };
            ItemSource.RandomizeOrder();
            _currentSortedPosition = 0;
        }

        #region -- Public properties --

        private ObservableCollection<SelectedButtonViewModel> _itemSource;
        public ObservableCollection<SelectedButtonViewModel> ItemSource
        {
            get => _itemSource;
            set => SetItemSource(value);
        }

        #endregion

        #region -- Private helpers --

        private void OnButtonClickCommandHandler(object param)
        {
            if (!(param is EButtonType))
                return;
            EButtonType current = (EButtonType)param;

            if (ItemSource.IsAnotherSelected(current, _currentSortedPosition))
            {
                ItemSource.UnselectAll(_currentSortedPosition);
                ItemSource.ReselectIfOrdered(current, _currentSortedPosition);
                return;
            }

            ItemSource.ReselectIfOrdered(current, _currentSortedPosition);

            int selected = ItemSource.GetSelectedByType(current, _currentSortedPosition);

            if (selected < 4)
                return;

            ItemSource.ReorderByType(current, _currentSortedPosition);
            _currentSortedPosition += 4;

            if (_currentSortedPosition == 16)
                EndGame();
        }

        private void SetItemSource(ObservableCollection<SelectedButtonViewModel> value)
        {
            if (value.Count == 16)
                SetProperty(ref _itemSource, value, propertyName: nameof(ItemSource));
        }

        private async void EndGame()
        {
            NavigationParameters navigationParameters = new NavigationParameters();
            long ticks = DateTime.Now.Ticks - _startTimeStamp;
            TimeSpan span = TimeSpan.FromTicks(ticks);
            string stringResult = string.Format("{0}m {1}s {2}ms", span.Minutes, span.Seconds, span.Milliseconds);

            navigationParameters.Add("result", stringResult);

            await Task.Delay(1000);
            await _pageDialogService.DisplayAlertAsync("Congrats, " + _player + "!", "Youu pass game in " + stringResult + "!", "Accept");
            //await NavigationService.NavigateAsync("/NavigationPage/ResultPage", navigationParameters);
        }

        #endregion

        #region -- Overrides --

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            parameters.Add("player", _player);
            parameters.Add("game", "Buttons");
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            _player = parameters.GetValue<string>("player");
        }

        #endregion

    }
}
