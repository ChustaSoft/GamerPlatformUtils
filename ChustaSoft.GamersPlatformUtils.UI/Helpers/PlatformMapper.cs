using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.UI.Models;

namespace ChustaSoft.GamersPlatformUtils.UI.Helpers
{
    public static class PlatformMapper
    {

        public static SelectablePlatform Map(IPlatform source)
        {
            return new SelectablePlatform 
            { 
                Name = source.Name,
                Selected = true
            };
        }

    }
}
