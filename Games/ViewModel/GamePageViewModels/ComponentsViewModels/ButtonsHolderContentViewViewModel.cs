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
    public class ButtonsHolderContentViewViewModel : BindableBase, IDestructible
    {
        private EButtonType _currentType;
        public EButtonType CurrentType
        {
            get
            {
                return _currentType;
            }
            set
            {
                SetProperty(ref _currentType, value);
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                SetProperty(ref _isSelected, value);
            }
        }

        private ICommand _buttonClick;
        public ICommand ButtonClick
        {
            get
            {
                return _buttonClick;
            }
            set
            {
                SetProperty(ref _buttonClick, value);
            }
        }

        public ButtonsHolderContentViewViewModel(EButtonType currentType, IEventAggregator agregregator)
        {
            CurrentType = currentType;
            _buttonClick = new Command(() => agregregator.GetEvent<ButtonPressedEvent>().Publish(CurrentType));
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
