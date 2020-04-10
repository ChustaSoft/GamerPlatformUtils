using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Infrastructure
{
    public interface IFileRepository
    {
        Dictionary<string, string> Read(string path);

        void Write();

    }
}