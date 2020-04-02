using ChustaSoft.GamersPlatformUtils.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions.Contracts
{
    public interface ILinkFinder
    {
        string RootFolderName { get; set; }

        Task<IEnumerable<GameLink>> Find();
    }
}