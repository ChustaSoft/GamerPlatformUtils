using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.UI.Models;

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

    }
}
