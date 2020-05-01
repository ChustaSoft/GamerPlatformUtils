using ChustaSoft.GamersPlatformUtils.Domain;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Base;
using ChustaSoft.GamersPlatformUtils.UI.Styles;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI.Controls
{
    public class InformationControlViewModel : TraceableViewModelBase<Information>
    {

        public bool HasSteam
            => Model?.Platforms.Any(x => x.Name.Equals(SteamConstants.PLATFORM_NAME)) ?? false;

        public bool HasOrigin
            => Model?.Platforms.Any(x => x.Name.Equals(OriginConstants.PLATFORM_NAME)) ?? false;

        public bool HasXbox
            => true;


        public InformationControlViewModel(ILogger logger)
            : base(logger)
        { }


        #region Styles

        public Thickness IconsMargins => StyleConstants.HorizontalCommonMargins;

        #endregion

    }
}
