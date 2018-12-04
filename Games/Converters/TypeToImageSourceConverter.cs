using System;
using System.Globalization;
using Xamarin.Forms;
using Games.Model;
namespace Games.Converters
{
    public class TypeToImageSourceConverter : IValueConverter
    {

        public TypeToImageSourceConverter()
        {
            One = ImageSource.FromFile("a.png");
            Two = ImageSource.FromFile("b.png");
            Three = ImageSource.FromFile("c.png");
            Four = ImageSource.FromFile("d.png");
        }

        public ImageSource One { get; set; }

        public ImageSource Two { get; set; }

        public ImageSource Three { get; set; }

        public ImageSource Four { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is EButtonType))
                return null;
            EButtonType current = (EButtonType)value;

            switch (current)
            {
                case EButtonType.NONE:
                    return null;
                case EButtonType.ONE:
                    return One;
                case EButtonType.TWO:
                    return Two;
                case EButtonType.THREE:
                    return Three;
                case EButtonType.FOUR:
                    return Four;
            }

            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
