using Microsoft.Extensions.Logging;

namespace ChustaSoft.GamersPlatformUtils.Services
{
    public class ServiceBase
    {

        protected readonly ILogger _logger;


        protected ServiceBase(ILogger logger)
        {
            _logger = logger;
        }

    }
}
