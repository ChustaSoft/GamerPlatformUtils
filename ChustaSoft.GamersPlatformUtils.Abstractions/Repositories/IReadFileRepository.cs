using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface IReadFileRepository
    {
        IDictionary<string, string> Read(string path);
    }
}