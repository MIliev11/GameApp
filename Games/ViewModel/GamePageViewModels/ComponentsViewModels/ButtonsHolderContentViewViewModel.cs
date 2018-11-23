using System;
using Prism.Mvvm;
using System.ComponentModel;
using Games.Model.ButtonsGame;
using Prism.Events;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using Games.Events;

namespace Games.ViewModel.GamePageViewModels.ComponentsViewModels
{
    public class ButtonsHolderContentViewViewModel : BindableBase
    {

        private IEventAggregator _eventAgregator;

        public ButtonsHolderContentViewViewModel(EButtonType currentType, IEventAggregator agregregator)
        {
            CurrentType = currentType;
            _eventAgregator = agregregator;
            _buttonClick = new Command(OnButtonClickHandler);
        }

        #region -- Public properties --

        private EButtonType _currentType;
        public EButtonType CurrentType
        {
            get => _currentType;
            set
            {
                SetProperty(ref _currentType, value);
                RaisePropertyChanged(nameof(CurrentType));
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (!IsOrdered)
                {
                    SetProperty(ref _isSelected, value);
                    RaisePropertyChanged(nameof(IsSelected));
                }
            }
        }

        private bool _isOrdered;
        public bool IsOrdered
        {
            get => _isOrdered;
            set
            {
                if (value)
                    IsSelected = true;
                SetProperty(ref _isOrdered, value);
                RaisePropertyChanged(nameof(IsOrdered));
            }
        }

        private ICommand _buttonClick;
        public ICommand ButtonClick
        {
            get => _buttonClick;
            set => SetProperty(ref _buttonClick, value);
        }

        #endregion

        #region -- Private helpers --

        private void OnButtonClickHandler()
        {
            IsSelected = !IsSelected;
            _eventAgregator.GetEvent<ButtonPressedEvent>().Publish(CurrentType);
        }

        #endregion

    }
}
