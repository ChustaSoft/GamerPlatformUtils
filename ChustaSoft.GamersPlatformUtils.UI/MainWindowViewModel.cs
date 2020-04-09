using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Base;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    public class MainWindowViewModel : ViewModelBase<Information>
    {
        
        public MainWindowViewModel(ILoadService<Information> informationService)
            : base(informationService)
        { }

        public MainWindowViewModel(object information) 
            : base(information)
        { }

        public void LoadTest() 
        { 
        
        }

    }
}
