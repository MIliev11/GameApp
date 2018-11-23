using System;
using System.Windows.Input;
using Xamarin.Forms;
using Games.Model.ButtonsGame;
using Games.ViewModel.GamePageViewModels.ComponentsViewModels;
using System.Threading.Tasks;

namespace Games.View.GamePages.Components.ButtonsGameUIElements
{
    public partial class ButtonHolderContentView : ContentView
    {

        public ButtonHolderContentView()
        {
            InitializeComponent();
            BindingContextChanged += ButtonHolderContentView_BindingContextChanged;
        }

        #region -- Public static vars --

        public static BindableProperty CurrentColorProperty = BindableProperty.Create("CurrentColor", typeof(Color), typeof(ButtonHolderContentView), Color.White, BindingMode.TwoWay);

        public static BindableProperty SelectedColorProperty = BindableProperty.Create("SelectedColor", typeof(Color), typeof(ButtonHolderContentView), Color.Black, BindingMode.TwoWay);

        public static BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(ImageSource), typeof(ButtonHolderContentView), ImageSource.FromFile(""), BindingMode.TwoWay);

        public static BindableProperty ButtonTypeProperty = BindableProperty.Create("ButtonType", typeof(EButtonType), typeof(ButtonHolderContentView), EButtonType.One, BindingMode.TwoWay, propertyChanged: OnButtonTypePropertyChanged);

        public static BindableProperty SelectedProperty = BindableProperty.Create("Selected", typeof(bool), typeof(ButtonHolderContentView), false, BindingMode.TwoWay, propertyChanged: OnSelectedPropertyChanged);

        public static BindableProperty OrderedProperty = BindableProperty.Create("Ordered", typeof(bool), typeof(ButtonHolderContentView), false, BindingMode.TwoWay, propertyChanged: OnSelectedPropertyChanged);

        public static BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ButtonHolderContentView), null, BindingMode.TwoWay);

        #endregion

        #region -- Public properties --

        public Color CurrentColor
        {
            get => (Color)GetValue(CurrentColorProperty);
            set => SetValue(CurrentColorProperty, value);
        }

        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }

        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public EButtonType ButtonType
        {
            get => (EButtonType)GetValue(ButtonTypeProperty);
            set
            {
                SetValue(ButtonTypeProperty, value);
                ChangeTypeTo(value);
            }
        }

        public bool Selected
        {
            get => (bool)GetValue(SelectedProperty);
            set
            {
                SetValue(SelectedProperty, value);
                CurrentColor = value ? SelectedColor : Color.White;
            }
        }

        public bool Ordered
        {
            get => (bool)GetValue(OrderedProperty);
            set
            {
                Selected = true;
                SetValue(OrderedProperty, value);
            }
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        #endregion

        #region -- Private helpers --

        private Task ChangeTypeTo(EButtonType type)
        {
            switch (ButtonType)
            {
                case EButtonType.One:
                    SelectedColor = Color.Blue;
                    ImageSource = ImageSource.FromResource("Games.Resources.a.png");
                    break;
                case EButtonType.Two:
                    SelectedColor = Color.Yellow;
                    ImageSource = ImageSource.FromResource("Games.Resources.b.png");
                    break;
                case EButtonType.Three:
                    SelectedColor = Color.Green;
                    ImageSource = ImageSource.FromResource("Games.Resources.c.png");
                    break;
                case EButtonType.Four:
                    SelectedColor = Color.Red;
                    ImageSource = ImageSource.FromResource("Games.Resources.d.png");
                    break;
            }
            CurrentColor = Selected ? SelectedColor : Color.White;

            return new Task(() => { });
        }

        private async void ButtonHolderContentView_BindingContextChanged(object sender, EventArgs e)
        {
            var t = (ButtonHolderContentView)sender;
            if (t.BindingContext == null) return;
            await ChangeTypeTo(((ButtonsHolderContentViewViewModel)t.BindingContext).CurrentType);
        }

        private void Handle_Tapped(object sender, System.EventArgs e)
        {
            Command?.Execute(null);
        }

        #endregion

        #region -- Private static methods --

        private static void OnButtonTypePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((ButtonHolderContentView)bindable).ButtonType = (EButtonType)newvalue;
        }

        private static void OnOrderedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((ButtonHolderContentView)bindable).Ordered = (bool)newvalue;
        }

        private static void OnSelectedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((ButtonHolderContentView)bindable).Selected = (bool)newvalue;
        }

        #endregion

    }
}
