using ChustaSoft.GamersPlatformUtils.Services;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(IInformationService informationService)
        {
            DataContext = new MainWindowViewModel(informationService);
            
            InitializeComponent();
        }

    }
}
