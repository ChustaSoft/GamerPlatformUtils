using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface IFileRepository
    {
        IDictionary<string, string> Read(string path);

        void Write();

    }
}