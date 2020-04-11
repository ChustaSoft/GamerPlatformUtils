using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain.Implementations;
using ChustaSoft.GamersPlatformUtils.Infrastructure;
using ChustaSoft.GamersPlatformUtils.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPlatformFactory, PlatformFactory>();
            services.AddScoped<ILoadService<Information>, InformationService>();

            services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<ILoadService<Information>>()));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

    }
}
