using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChustaSoft.GamersPlatformUtils.UI.Helpers
{
    public static class PlatformMapper
    {

        public static SelectableOption Map(IPlatform source)
        {
            return new SelectableOption 
            { 
                Name = source.Name,
                Selected = true
            };
        }

        public static ObservableCollection<SelectableOption> Map(this IEnumerable<IPlatform> source)
            => new ObservableCollection<SelectableOption>(source.Select(Map));

    }
}
