using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    public partial class App : Application
    {

        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            _serviceProvider = ServiceConfigurationExtensions.Init()
                .ConfigureGeneral()
                .ConfigureDomain()
                .ConfigureServices()
                .ConfigureRepositories()
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            LogApplicationStartup();

            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }


        private void LogApplicationStartup()
        {
            var logger = _serviceProvider.GetLogger();
            logger.LogInformation("Application started");
        }

    }
}
