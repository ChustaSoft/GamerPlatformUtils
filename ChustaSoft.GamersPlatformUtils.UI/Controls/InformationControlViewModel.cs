using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain.Constants;
using ChustaSoft.GamersPlatformUtils.UI.Base;
using System.Linq;

namespace ChustaSoft.GamersPlatformUtils.UI.Controls
{
    public class InformationControlViewModel : ViewModelBase<Information>
    {

        public bool HasSteam
            => ViewModel?.Platforms.Any(x => x.Name.Equals(SteamConstants.PLATFORM_NAME)) ?? false;

        public bool HasOrigin
            => ViewModel?.Platforms.Any(x => x.Name.Equals("Origin")) ?? false;

        public bool HasXbox
            => true;


        public InformationControlViewModel(object dataContext)
            : base(dataContext)
        { }

    }
}
