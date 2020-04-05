using System.Collections.Generic;
using System.IO;

namespace ChustaSoft.GamersPlatformUtils.Infrastructure
{
    public interface IDirectoryRepository
    {
        void CleanDirectory(string path);

        void WriteDirectory(FileInfo fileInfo);

        IEnumerable<FileInfo> ReadDirectory(string path);

    }
}