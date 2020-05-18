using ChustaSoft.Common.Base;
using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Abstractions;
using System.Collections.ObjectModel;
using System.IO;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Linker
{
    public class LinkerControlModel : ViewModelBase
    {

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private ObservableCollection<SelectableOption> _platformsSource;
        public ObservableCollection<SelectableOption> PlatformsSource
        {
            get { return _platformsSource; }
            set { 
                _platformsSource = value;
                OnPropertyChanged(nameof(PlatformsSource));
            }
        }

        private ObservableCollection<SelectableOption> _platformsDestination;
        public ObservableCollection<SelectableOption> PlatformsDestination
        {
            get { return _platformsDestination; }
            set
            {
                _platformsDestination = value;
                OnPropertyChanged(nameof(PlatformsDestination));
            }
        }

        private ObservableCollection<SelectableOption<GameLink>> _pathsAnalyzed;
        public ObservableCollection<SelectableOption<GameLink>> PathsAnalyzed
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
            PlatformsSource = new ObservableCollection<SelectableOption>();
            PlatformsDestination = new ObservableCollection<SelectableOption>();
            PathsAnalyzed = new ObservableCollection<SelectableOption<GameLink>>(); 
        }

    }
}
