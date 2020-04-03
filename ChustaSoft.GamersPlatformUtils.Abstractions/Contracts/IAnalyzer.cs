using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions.Contracts
{
    public interface IAnalyzer
    {
        Task<IEnumerable<FileInfo>> AnalyzeAsync(string path);
    }
}
