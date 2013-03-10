using System;
using System.Globalization;
using System.Windows.Data;

namespace LearnTamil
{
    public class IsFlippedToCardRotationXConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isFlipped = Parse(value);
            return isFlipped ? 180 : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private bool Parse(object value)
        {
            return value == null
                ? false
                : bool.Parse(value.ToString());
        }
    }
}
