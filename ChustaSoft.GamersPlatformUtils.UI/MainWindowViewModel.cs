using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Base;
using ChustaSoft.GamersPlatformUtils.UI.Contracts;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    public class MainWindowViewModel : ViewModelBase<Information>, ILoadable<Information>
    {

        private readonly ILoadService<Information> _informationService;

        public MainWindowViewModel(ILoadService<Information> informationService)
            : base()
        {
            _informationService = informationService;
            _informationService.LoadEvent += OnLoadCompleted;
        }

        public MainWindowViewModel()
            : base()
        { }


        public void OnLoad() => _informationService.Load();


        private void OnLoadCompleted(object sender, Information information)
        {
            Model = information;
        }

    }
}
