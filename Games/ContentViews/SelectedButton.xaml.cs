using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Games.Model;

namespace Games.ContentViews
{
    public partial class SelectedButton : ContentView
    {

        public SelectedButton()
        {
            InitializeComponent();
        }

        #region -- Public properties --

        public static BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool), typeof(SelectedButton), false, propertyChanged: OnIsSelectedPropertyChanged);
        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public static BindableProperty SelectedColorProperty = BindableProperty.Create("SelectedColor", typeof(Color), typeof(SelectedButton), Color.White);
        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }

        public static BindableProperty StockColorProperty = BindableProperty.Create("StockColor", typeof(Color), typeof(SelectedButton), Color.White);
        public Color StockColor
        {
            get => (Color)GetValue(StockColorProperty);
            set => SetValue(StockColorProperty, value);
        }

        #endregion

        #region -- Private static methods --

        private static void OnIsSelectedPropertyChanged(BindableObject sender, object oldValue, object newValue)
        {
            if (!(sender is SelectedButton) && !(newValue is bool))
                return;
            SelectedButton current = sender as SelectedButton;

            current.BackgroundColor = current.IsSelected ? current.SelectedColor : current.StockColor;
        }

        #endregion

    }
}