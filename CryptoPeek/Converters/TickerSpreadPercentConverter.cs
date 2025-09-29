using System.Globalization;
using System.Windows.Data;

namespace CryptoPeek.Converters
{
    public class TickerSpreadPercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal dec)
            {
                return $"{dec.ToString("G29", CultureInfo.InvariantCulture)}%";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
