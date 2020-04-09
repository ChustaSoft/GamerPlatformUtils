using System.Collections.Generic;
using System.IO;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface IDirectoryRepository
    {
        void Clean(string path);

        void Write(FileInfo fileInfo);

        IEnumerable<FileInfo> Read(string path);

    }
}