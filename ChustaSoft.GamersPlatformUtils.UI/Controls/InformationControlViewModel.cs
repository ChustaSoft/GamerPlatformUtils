using ChustaSoft.GamersPlatformUtils.Domain.Constants;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Base;
using System.Linq;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI.Controls
{
    public class InformationControlViewModel : ViewModelBase<Information>
    {

        private const double ICONS_VERTICAL_MARGIN = 0;
        private const double ICONS_HORIZONTAL_MARGIN = 5;

        public bool HasSteam
            => ViewModel.Platforms.Any(x => x.Name.Equals(SteamConstants.PLATFORM_NAME));

        public bool HasOrigin
            => ViewModel.Platforms.Any(x => x.Name.Equals("Origin"));

        public bool HasXbox
            => true;

        public Thickness IconsMargins 
            => new Thickness(ICONS_HORIZONTAL_MARGIN, ICONS_VERTICAL_MARGIN, ICONS_HORIZONTAL_MARGIN, ICONS_VERTICAL_MARGIN);


        public InformationControlViewModel(object dataContext)
            : base(dataContext)
        { }

    }
}
