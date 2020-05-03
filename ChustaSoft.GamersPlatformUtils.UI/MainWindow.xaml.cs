using Microsoft.Extensions.Logging;
using System;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    public partial class MainWindow : Window
    {

        public MainWindow(IServiceProvider serviceProvider, ILogger logger)
        {
            DataContext = new MainWindowViewModel(logger, serviceProvider);
            
            InitializeComponent();
        }

    }
}
