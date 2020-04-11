using ChustaSoft.GamersPlatformUtils.UI.Controls;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ChustaSoft.GamersPlatformUtils.UI.Converters
{
    public class InformationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new InformationControlViewModel(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new MainWindowViewModel(value);
        }
    }
}
