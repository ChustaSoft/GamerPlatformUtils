using ChustaSoft.GamersPlatformUtils.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions.Contracts
{
    public interface ILinkAssigner
    {
        Task<bool> Assign(IEnumerable<GameLink> gameLinks);
    }
}