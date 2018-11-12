using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Games.View.Components
{
    public partial class ButtonHolderContentView : ContentView
    {

        public int XGridPosition { get; set; }

        public int YGridPosition { get; set; }

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

        public ButtonHolderContentView()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            IsSelected = !IsSelected;
            if (IsSelected)
            {
                Command?.Execute(null);
            }
        }
    }
}
