using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface ILinkFinder
    {
        string RootFolderName { get; set; }

        Task<IEnumerable<GameLink>> FindAsync();
    }
}