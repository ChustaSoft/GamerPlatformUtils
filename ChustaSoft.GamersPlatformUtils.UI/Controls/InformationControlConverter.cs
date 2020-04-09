using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ChustaSoft.GamersPlatformUtils.UI.Controls
{
    public class InformationControlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new InformationControlViewModel
            {
                Model = (Information)value
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new MainWindowViewModel
            {
                Model = (Information)value
            };
        }
    }
}
