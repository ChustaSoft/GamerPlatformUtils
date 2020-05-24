using ChustaSoft.Common.Base;
using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Abstractions;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Linker
{
    public class LinkerControlModel : ViewModelBase
    {

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
                OnPropertyChanged(nameof(HasResults));
            }
        }

        public bool HasResults => PathsAnalyzed.Any();


        public LinkerControlModel()
        {
            SetEmptyPlatforms();
            SetEmptyPaths();
        }


        internal void ClearPaths()
        {
            SetEmptyPaths();
        }

        internal void ChangeAllPathsSelection(bool multipleSelection)
        {
            foreach (var filePathSelect in PathsAnalyzed)
                filePathSelect.Selected = multipleSelection;
        }

        private void SetEmptyPlatforms()
        {
            PlatformsSource = new ObservableCollection<SelectableOption>();
            PlatformsDestination = new ObservableCollection<SelectableOption>();
        }

        private void SetEmptyPaths()
        {
            PathsAnalyzed = new ObservableCollection<SelectableOption<GameLink>>();
        }

    }
}
