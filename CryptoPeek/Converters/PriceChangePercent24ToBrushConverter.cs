using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CryptoPeek.Converters
{
    public class PriceChangePercent24ToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (decimal.TryParse(value.ToString(), out var percent))
            {
                return percent > 0 ? Brushes.Green
                                   : percent < 0
                                   ? Brushes.Red
                                   : Brushes.Black;
            }

            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
