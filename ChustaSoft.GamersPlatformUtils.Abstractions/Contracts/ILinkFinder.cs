using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface ILinkFinder
    {
        Task<IEnumerable<GameLink>> FindAsync();
    }
}