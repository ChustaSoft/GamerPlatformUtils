using ChustaSoft.GamersPlatformUtils.Domain;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Base;
using ChustaSoft.GamersPlatformUtils.UI.Styles;
using System.Linq;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI.Controls
{
    public class InformationControlViewModel : ViewModelBase<Information>
    {

        public bool HasSteam
            => Model?.Platforms.Any(x => x.Name.Equals(SteamConstants.PLATFORM_NAME)) ?? false;

        public bool HasOrigin
            => Model?.Platforms.Any(x => x.Name.Equals(OriginConstants.PLATFORM_NAME)) ?? false;

        public bool HasXbox
            => true;


        #region Styles

        public Thickness IconsMargins => StyleConstants.HorizontalCommonMargins;

        #endregion

    }
}
