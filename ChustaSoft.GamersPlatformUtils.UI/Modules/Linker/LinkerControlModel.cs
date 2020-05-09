using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.UI.Base;
using ChustaSoft.GamersPlatformUtils.UI.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Linker
{
    public class LinkerControlModel : ViewModelBase
    {

        private ObservableCollection<SelectablePlatform> _platformsSource;
        public ObservableCollection<SelectablePlatform> PlatformsSource
        {
            get { return _platformsSource; }
            set { 
                _platformsSource = value;
                OnPropertyChanged(nameof(PlatformsSource));
            }
        }

        private ObservableCollection<SelectablePlatform> _platformsDestination;
        public ObservableCollection<SelectablePlatform> PlatformsDestination
        {
            get { return _platformsDestination; }
            set
            {
                _platformsDestination = value;
                OnPropertyChanged(nameof(PlatformsDestination));
            }
        }

        private ObservableCollection<SelectableItem> _pathsAnalyzed;
        public ObservableCollection<SelectableItem> PathsAnalyzed
        {
            get { return _pathsAnalyzed; }
            set
            {
                _pathsAnalyzed = value;
                OnPropertyChanged(nameof(PathsAnalyzed));
            }
        }


        public LinkerControlModel() 
        {
            PlatformsSource = new ObservableCollection<SelectablePlatform>();
            PlatformsDestination = new ObservableCollection<SelectablePlatform>();
            PathsAnalyzed = new ObservableCollection<SelectableItem>(); 
        }

    }
}
