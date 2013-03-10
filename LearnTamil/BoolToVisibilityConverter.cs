using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LearnTamil
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visible = this.Parse(value);
            var negate = this.Parse(parameter);
            if (negate)
            {
                visible = !visible;
            }

            return visible ? Visibility.Visible : Visibility.Collapsed;
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
