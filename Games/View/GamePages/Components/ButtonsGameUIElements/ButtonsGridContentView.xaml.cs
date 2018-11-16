using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Games.ViewModel.GamePageViewModels.ComponentsViewModels;
using System.Windows.Input;
using Games.Model.ButtonsGame;
using static Xamarin.Forms.BindableProperty;
using Games.Extentions;
using Prism.Events;
using Games.Events;

namespace Games.View.GamePages.Components.ButtonsGameUIElements
{
    public partial class ButtonsGridContentView : ContentView
    {

        public ButtonsGridContentView()
        {
            InitializeComponent();
            IEventAggregator aggregator = DependencyService.Get<IEventAggregator>();
            ButtonPressedEvent eventd = aggregator.GetEvent<ButtonPressedEvent>();
            //eventd.Subscribe((type) =>
            //{
            //    EButtonType collected = Items.CollectedButtons();
            //    if (type == EButtonType.Null)
            //        return;
            //    if (type != collected)
            //        Items.UnselectAll();
            //});
            //this.GetType();
        }

        #region -- Public properties --

        public static BindableProperty ItemsProperty = BindableProperty.Create("Items", typeof(ObservableCollection<ButtonsHolderContentViewViewModel>), typeof(ButtonsGridContentView), null, BindingMode.TwoWay);
        public ObservableCollection<ButtonsHolderContentViewViewModel> Items
        {
            get
            {
                return (ObservableCollection<ButtonsHolderContentViewViewModel>)GetValue(ItemsProperty);
            }
            set
            {
                SetValue(ItemsProperty, value);
            }
        }

        public static BindableProperty OnGameEndsProperty = BindableProperty.Create("OnGameEnds", typeof(ICommand), typeof(ButtonsGridContentView), null, BindingMode.TwoWay);
        public ICommand OnGameEnds
        {
            get
            {
                return (ICommand)GetValue(OnGameEndsProperty);
            }
            set
            {
                SetValue(OnGameEndsProperty, value);
            }
        }

        #endregion

    }
}
