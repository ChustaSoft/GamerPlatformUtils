using ChustaSoft.GamersPlatformUtils.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.Services
{
    public class InformationService : IInformationService
    {

        private readonly IPlatformFactory _platformFactory;


        public event EventHandler<Information> InformationEvent;


        public InformationService(IPlatformFactory platformFactory)
        {
            _platformFactory = platformFactory;
        }


        public void Load()
        {
            Task.Run(() => 
            {
                var platforms = _platformFactory.GetPlatforms();

                InformationEvent?.Invoke(this, new Information
                {
                    MachineName = Environment.MachineName,
                    OperartiveSystem = Environment.OSVersion,
                    Platforms = platforms.Where(x => x.Available)
                });
            });
        }

    }
}
