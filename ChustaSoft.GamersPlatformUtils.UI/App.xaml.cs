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
            _serviceProvider = ServiceProviderBuilder.Init()
                .ConfigureDomain()
                .ConfigureServices()
                .ConfigureRepositories()
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

    }
}
