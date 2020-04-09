using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain.Constants;
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
            => Model?.Platforms.Any(x => x.Name.Equals("Origin")) ?? false;

        public bool HasXbox
            => true;


        #region Styles

        public Thickness IconsMargins => StyleConstants.HorizontalCommonMargins;

        #endregion

    }
}
