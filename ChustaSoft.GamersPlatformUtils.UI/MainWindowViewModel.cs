using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Base;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    public class MainWindowViewModel : ViewModelBase
    {
        
        private IInformationService _informationService;
        private Information _information;

        public Information Information
        {
            get 
            { 
                return _information; 
            }
            set 
            { 
                _information = value;
                OnPropertyChanged(nameof(Information));
            }
        }

        public MainWindowViewModel(IInformationService informationService)
        {
            _informationService = informationService;

            _informationService.InformationEvent += OnInformationChanged;
            _informationService.Load();
        }

        private void OnInformationChanged(object sender, Information information)
        {
            _information = information;
        }

    }
}
