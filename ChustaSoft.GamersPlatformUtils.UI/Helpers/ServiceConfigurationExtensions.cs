﻿using Chustasoft.GamersPlatformUtils.Infrastructure.Implementations;
using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain;
using ChustaSoft.GamersPlatformUtils.Infrastructure;
using ChustaSoft.GamersPlatformUtils.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    public static class ServiceConfigurationExtensions
    {

        private const string APP_LOG_FILENAME = "cs-gputils.app.log";


        public static ServiceCollection Init() => new ServiceCollection();


        public static ServiceCollection ConfigureGeneral(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddLogging(configure => configure.AddFile(APP_LOG_FILENAME, append: true));
            serviceCollection.AddSingleton<ILogger>(s => s.GetLogger());

            return serviceCollection;
        }

        internal static ServiceCollection ConfigureDomain(this ServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<ISteamBusiness, SteamBusiness>();
            serviceCollection.AddScoped<IOriginBusiness, OriginBusiness>();
            serviceCollection.AddScoped<IXboxBusiness, XboxBusiness>();

            return serviceCollection;
        }

        internal static ServiceCollection ConfigureServices(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IPlatformFactory, PlatformFactory>();
            serviceCollection.AddScoped<ILoadService<Information>, InformationService>();
            serviceCollection.AddScoped<IAnalyzerService, AnalyzerService>();
            serviceCollection.AddScoped<ILinkerService, LinkerService>();
            serviceCollection.AddScoped<IFileService, FileService>();
            serviceCollection.AddSingleton<MainWindow>(s => new MainWindow(s, s.GetRequiredService<ILogger>()));

            return serviceCollection;
        }

        internal static ServiceCollection ConfigureRepositories(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<XMLFileRepository>();
            serviceCollection.AddScoped<VDFFileRepository>();
            serviceCollection.AddScoped<PowershellFileRepository>();
            serviceCollection.AddTransient<ServiceResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case RepositoriesDefinition.XML_REPOSITORY:
                        return serviceProvider.GetService<XMLFileRepository>();
                    case RepositoriesDefinition.VDF_REPOSITORY:
                        return serviceProvider.GetService<VDFFileRepository>();
                    case RepositoriesDefinition.POWERSHELL_REPOSITORY:
                        return serviceProvider.GetService<PowershellFileRepository>();
                    
                    default:
                        throw new KeyNotFoundException();
                }
            });
            serviceCollection.AddScoped<IFileDeleteRepository, SystemFileRepository>();

            return serviceCollection;
        }

        internal static ServiceProvider Build(this ServiceCollection serviceCollection)
        {
            return serviceCollection.BuildServiceProvider();
        }

        internal static ILogger GetLogger(this IServiceProvider serviceProvider) 
            => serviceProvider.GetRequiredService<ILoggerProvider>().CreateLogger("DEBUG");

    }

}
