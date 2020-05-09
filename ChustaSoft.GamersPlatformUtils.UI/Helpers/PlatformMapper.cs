﻿using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Abstractions;

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
