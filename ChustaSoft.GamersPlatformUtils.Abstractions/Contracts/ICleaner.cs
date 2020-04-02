﻿using ChustaSoft.GamersPlatformUtils.Abstractions.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions.Contracts
{
    public interface ICleaner
    {
        Task<CleanResult> CleanAsync(IEnumerable<FileInfo> paths);
    }
}
