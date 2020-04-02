using ChustaSoft.GamersPlatformUtils.Abstractions.Models;
using System;

namespace ChustaSoft.GamersPlatformUtils.Abstractions.Contracts
{
    public interface IPlatform
    {
        string Name { get; set; }
        string Brand { get; set; }

        Platform GetInformation();
    }
}