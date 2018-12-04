using System;
using Prism.Mvvm;
using Xamarin.Forms;
using System.Windows.Input;
using Games.Model;

namespace Games.ControllsViewModels
{
    public class SelectedButtonViewModel : BindableBase
    {

        private ICommand _viewModelActionCommand;

        public SelectedButtonViewModel(EButtonType currentType, ICommand viewModelAction)
        {
            CurrentType = currentType;
            _viewModelActionCommand = viewModelAction;
            ButtonClickedCommand = new Command(ButtonClickedCommandHandle);
        }

        #region -- Public property --

        private EButtonType _currentType;
        public EButtonType CurrentType
        {
            get => _currentType;
            set => SetProperty(ref _currentType, value);
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public ICommand ButtonClickedCommand { get; private set; }

        #endregion

        #region -- Private helpers --

        private void ButtonClickedCommandHandle()
        {
            IsSelected = !IsSelected;

            _viewModelActionCommand?.Execute(CurrentType);
        }

        #endregion

    }
}
