using System;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(IServiceProvider serviceProvider)
        {
            DataContext = new MainWindowViewModel(serviceProvider);
            
            InitializeComponent();
        }

    }
}
