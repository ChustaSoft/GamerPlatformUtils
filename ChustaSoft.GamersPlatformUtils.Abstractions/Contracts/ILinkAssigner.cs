using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface ILinkAssigner
    {
        Task<bool> AssignAsync(IEnumerable<GameLink> gameLinks);
    }
}