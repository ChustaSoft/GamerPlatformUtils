using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;

namespace ChustaSoft.GamersPlatformUtils.Services
{
    public interface IInformationService
    {
        event EventHandler<Information> InformationEvent;

        void Load();

    }
}
