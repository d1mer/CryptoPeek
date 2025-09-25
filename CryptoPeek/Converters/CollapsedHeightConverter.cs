using System.Globalization;
using System.Windows.Data;

namespace CryptoPeek.Converters
{
    public class CollapsedHeightConverter : IMultiValueConverter
    {
        // values [0] - IsExpanded (bool)
        //        [1] - CollapsedLines (int)
        //        [2] - FontSize (double)
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool isExpanded = default;
            int lines = default;
            double fontSize = default;

            if (values.Length > 0 && values[0] is bool b) 
            {
                isExpanded = b;
            }

            if (values.Length > 1 && values[1] is int i)
            {
                lines = i > 0 ? i : 3;
            }
            else
            {
                lines = 3;
            }

            if (values.Length > 2 && values[2] is double d)
            {
                fontSize = d;
            }
            else
            {
                fontSize = 14.0;
            }

            return isExpanded
                   ? double.PositiveInfinity
                   : lines * fontSize * 1.35;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
