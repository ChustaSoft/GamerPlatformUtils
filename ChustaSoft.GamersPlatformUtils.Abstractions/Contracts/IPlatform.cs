using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public interface IPlatform
    {

        bool Available { get; }

        string Name { get; }

        string Brand { get; }

        string AppPath { get; }

        IEnumerable<string> Libraries { get; }

    }
}