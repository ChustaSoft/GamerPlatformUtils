using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface IReadWriteFileRepository : IReadFileRepository
    {
        void Write();
    }
}