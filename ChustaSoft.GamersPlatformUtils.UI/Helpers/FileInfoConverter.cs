using System;
using System.Globalization;
using System.Windows.Data;

namespace ChustaSoft.GamersPlatformUtils.UI.Helpers
{
    public class FileInfoConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
