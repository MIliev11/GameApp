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
using Games.Events;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Games.ViewModel.GamePageViewModels
{
    public class ButtonsGamePageViewModel : ViewModelBase
    {
        private string _userName;

        public ButtonsGamePageViewModel(INavigationService navigation, IPageDialogService dialogService, IEventAggregator agregator) : base(navigation)
        {
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
            Stopwatch.StartNew();
            agregator.GetEvent<ButtonPressedEvent>().Subscribe((type) =>
            {
                EButtonType collected = ItemsSource.CollectedButtons();
                int Count = ItemsSource.GetNumberOfSelectedButton();

                if (collected == EButtonType.Null || (type == collected && Count < 4))
                    return;
                if (type != collected || ItemsSource.IsAnotherSelected(type))
                    ItemsSource.UnselectAll();
                if (type == collected && Count == 4)
                    ItemsSource.ReorderByType(collected);

                RaisePropertyChanged(nameof(ItemsSource));

                if (ItemsSource.IsAllOrdered())
                    agregator.GetEvent<GameEndsEvent>().Publish();
            });
            agregator.GetEvent<GameEndsEvent>().Subscribe(async () =>
            {
                long passedTime = Stopwatch.GetTimestamp();
                await Task.Delay(1000);
                await dialogService.DisplayAlertAsync("Congrats!", String.Format("You scored {0} points!", passedTime), "Submit");
                NavigationParameters parameters = new NavigationParameters();
                parameters.Add("Game", "Buttons");
                parameters.Add("Player", _userName);
                parameters.Add("Score", passedTime);
                await navigation.NavigateAsync(new System.Uri("https://Games.com/NavigationPage/GameChosePage/ScoreResultsPage", UriKind.Absolute), parameters);
            });
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

    }
}
