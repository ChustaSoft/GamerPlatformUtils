using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface IFileRepository
    {
        Dictionary<string, string> Read(string path);

        void Write();

    }
}