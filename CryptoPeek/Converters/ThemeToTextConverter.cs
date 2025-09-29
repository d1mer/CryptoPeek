using System.Globalization;
using System.Windows.Data;

namespace CryptoPeek.Converters
{
    public class ThemeToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isDarkTheme)
            {
                return isDarkTheme ? "Dark theme" : "Light theme";
            }

            return "Change theme";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
