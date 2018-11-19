using Xamarin.Forms;
using System.Collections.ObjectModel;
using Games.ViewModel.GamePageViewModels.ComponentsViewModels;
using System.Windows.Input;
using System.Collections.Generic;

namespace Games.View.GamePages.Components.ButtonsGameUIElements
{
    public partial class ButtonsGridContentView : ContentView
    {

        public ButtonsGridContentView()
        {
            InitializeComponent();
        }

        #region -- Public static vars --

        public static BindableProperty ItemsProperty = BindableProperty.Create("Items", typeof(List<ButtonsHolderContentViewViewModel>), typeof(ButtonsGridContentView), null, BindingMode.TwoWay);

        #endregion

        #region -- Public properties --

        public List<ButtonsHolderContentViewViewModel> Items
        {
            get => (List<ButtonsHolderContentViewViewModel>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        #endregion

    }
}
