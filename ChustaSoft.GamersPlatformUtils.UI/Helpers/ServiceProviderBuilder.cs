using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain;
using ChustaSoft.GamersPlatformUtils.Infrastructure;
using ChustaSoft.GamersPlatformUtils.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    public static class ServiceProviderBuilder
    {

        public static ServiceCollection Init() => new ServiceCollection();


        public static ServiceCollection ConfigureDomain(this ServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<ISteamBusiness, SteamBusiness>();
            serviceCollection.AddScoped<IOriginBusiness, OriginBusiness>();
            serviceCollection.AddScoped<IXboxBusiness, XboxBusiness>();

            return serviceCollection;
        }

        public static ServiceCollection ConfigureServices(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IPlatformFactory, PlatformFactory>();
            serviceCollection.AddScoped<ILoadService<Information>, InformationService>();
            serviceCollection.AddScoped<IAnalyzerService, AnalyzerService>();
            serviceCollection.AddSingleton<MainWindow>(s => new MainWindow(s));

            return serviceCollection;
        }

        public static ServiceCollection ConfigureRepositories(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IReadWriteFileRepository, XMLFileRepository>();
            serviceCollection.AddScoped<IReadFileRepository, PowershellFileRepository>();

            return serviceCollection;
        }

        public static ServiceProvider Build(this ServiceCollection serviceCollection)
        {
            return serviceCollection.BuildServiceProvider();
        }

    }
}
