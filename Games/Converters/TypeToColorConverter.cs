using System;
using System.Globalization;
using Xamarin.Forms;
using Games.Model;
namespace Games.Converters
{
    public class TypeToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is EButtonType))
                return Color.White;
            EButtonType current = (EButtonType)value;

            switch (current)
            {
                case EButtonType.NONE:
                    return Color.White;
                case EButtonType.ONE:
                    return Color.Blue;
                case EButtonType.TWO:
                    return Color.Yellow;
                case EButtonType.THREE:
                    return Color.Green;
                case EButtonType.FOUR:
                    return Color.Red;
            }

            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}