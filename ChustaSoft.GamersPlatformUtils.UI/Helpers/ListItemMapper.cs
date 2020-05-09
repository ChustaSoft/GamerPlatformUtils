using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.UI.Models;

namespace ChustaSoft.GamersPlatformUtils.UI.Helpers
{
    public static class ListItemMapper
    {

        public static SelectableItem Map(GameLink gameLink)
        {
            return new SelectableItem
            { 
                GameLink = gameLink,
                Selected = false,
                Name = gameLink.Name
            };
        }

    }
}
