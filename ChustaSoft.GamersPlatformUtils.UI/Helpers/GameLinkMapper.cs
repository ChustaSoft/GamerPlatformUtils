using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public static ObservableCollection<SelectableOption<GameLink>> Map(this IEnumerable<GameLink> source)
            => new ObservableCollection<SelectableOption<GameLink>>(source.Select(Map));

    }
}
