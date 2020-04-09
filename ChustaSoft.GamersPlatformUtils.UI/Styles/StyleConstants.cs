using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI.Styles
{
    public static class StyleConstants
    {

        private const double ICONS_VERTICAL_MARGIN = 0;
        private const double ICONS_HORIZONTAL_MARGIN = 5;

        public static Thickness HorizontalCommonMargins
            => new Thickness(ICONS_HORIZONTAL_MARGIN, ICONS_VERTICAL_MARGIN, ICONS_HORIZONTAL_MARGIN, ICONS_VERTICAL_MARGIN);

    }
}
