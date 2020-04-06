using System.Collections.Generic;
using System.IO;

namespace ChustaSoft.GamersPlatformUtils.Infrastructure
{
    public interface IDirectoryRepository
    {
        void Clean(string path);

        void Write(FileInfo fileInfo);

        IEnumerable<FileInfo> Read(string path);

    }
}