using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Games.ViewModel.GamePageViewModels.ComponentsViewModels;
using Xamarin.Forms;
namespace Games.Convertors
{
    public class ButtonViewModelConvertor : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (((ObservableCollection<ButtonsHolderContentViewViewModel>)value).Count == 0)
                return null;
            ButtonsHolderContentViewViewModel temp = ((ObservableCollection<ButtonsHolderContentViewViewModel>)value)[int.Parse(((string)parameter))];
            return temp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
