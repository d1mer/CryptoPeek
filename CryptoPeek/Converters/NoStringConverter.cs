using System.Globalization;
using System.Windows.Data;

namespace CryptoPeek.Converters
{
    public class NoStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value is string str && string.IsNullOrEmpty(str)) || value is null)
            {
                return "\u2014";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
