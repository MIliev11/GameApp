using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Games.Model.ButtonsGame;
using System.Collections.ObjectModel;
using Games.ViewModel.GamePageViewModels.ComponentsViewModels;
using System.Threading.Tasks;

namespace Games.View.GamePages.Components.ButtonsGameUIElements
{
    public partial class ButtonHolderContentView : ContentView
    {

        public static BindableProperty CurrentColorProperty = BindableProperty.Create("CurrentColor", typeof(Color), typeof(ButtonHolderContentView), Color.White, BindingMode.TwoWay);
        public Color CurrentColor
        {
            get
            {
                return (Color)GetValue(CurrentColorProperty);
            }
            set
            {
                SetValue(CurrentColorProperty, value);
            }
        }

        public static BindableProperty SelectedColorProperty = BindableProperty.Create("SelectedColor", typeof(Color), typeof(ButtonHolderContentView), Color.Black, BindingMode.TwoWay);
        public Color SelectedColor
        {
            get
            {
                return (Color)GetValue(SelectedColorProperty);
            }
            set
            {
                SetValue(SelectedColorProperty, value);
            }
        }

        public static BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool), typeof(ButtonHolderContentView), false, BindingMode.TwoWay);
        public bool IsSelected
        {
            get
            {
                return (bool)GetValue(IsSelectedProperty);
            }
            set
            {
                SetValue(IsSelectedProperty, value);
                CurrentColor = IsSelected ? SelectedColor : Color.White;
            }
        }

        public static BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ButtonHolderContentView), null, BindingMode.TwoWay);
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        public static BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(ImageSource), typeof(ButtonHolderContentView), ImageSource.FromFile(""), BindingMode.TwoWay);
        public ImageSource ImageSource
        {
            get
            {
                return (ImageSource)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }

        public static BindableProperty ButtonTypeProperty = BindableProperty.Create("ButtonType", typeof(EButtonType), typeof(ButtonHolderContentView), EButtonType.One, BindingMode.TwoWay);
        public EButtonType ButtonType
        {
            get
            {
                return (EButtonType)GetValue(ButtonTypeProperty);
            }
            set
            {
                SetValue(ButtonTypeProperty, value);
                ChangeTypeTo(value);
            }
        }

        private Task ChangeTypeTo(EButtonType type)
        {
            switch (ButtonType)
            {
                case EButtonType.One:
                    SelectedColor = Color.Blue;
                    ImageSource = ImageSource.FromFile("a.png");
                    break;
                case EButtonType.Two:
                    SelectedColor = Color.Yellow;
                    ImageSource = ImageSource.FromFile("b.png");
                    break;
                case EButtonType.Three:
                    SelectedColor = Color.Green;
                    ImageSource = ImageSource.FromFile("c.png");
                    break;
                case EButtonType.Four:
                    SelectedColor = Color.Red;
                    ImageSource = ImageSource.FromFile("d.png");
                    break;
            }
            return new Task(() => { });
        }

        public ButtonHolderContentView()
        {
            InitializeComponent();
            BindingContextChanged += ButtonHolderContentView_BindingContextChanged;
        }

        private async void ButtonHolderContentView_BindingContextChanged(object sender, EventArgs e)
        {
            var t = (ButtonHolderContentView)sender;
            if (t.BindingContext == null) return;
            await ChangeTypeTo(((ButtonsHolderContentViewViewModel)t.BindingContext).CurrentType);
        }

        private void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (IsSelected)
            {
                Command?.Execute(null);
            }
            IsSelected = !IsSelected;
        }

    }
}
