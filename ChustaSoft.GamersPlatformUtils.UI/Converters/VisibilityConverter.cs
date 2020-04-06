using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ChustaSoft.GamersPlatformUtils.UI.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var booleanValue = (bool)value;

            if (booleanValue)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibiliyValue = (Visibility)value;

            if (visibiliyValue == Visibility.Visible)
                return true;
            else
                return false;
        }
    }
}
