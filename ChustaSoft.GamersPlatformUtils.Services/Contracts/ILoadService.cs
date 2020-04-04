using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;

namespace ChustaSoft.GamersPlatformUtils.Services
{
    public interface ILoadService<T>
    {
        event EventHandler<T> LoadEvent;

        void Load();

    }
}
