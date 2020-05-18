using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Abstractions;

namespace ChustaSoft.GamersPlatformUtils.UI.Helpers
{
    public static class GameLinkMapper
    {

        public static SelectableOption<GameLink> Map(GameLink gameLink)
        {
            return new SelectableOption<GameLink>
            {
                Value = gameLink,
                Selected = false
            };
        }

    }
}
