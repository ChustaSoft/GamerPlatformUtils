using ChustaSoft.Common.Base;
using ChustaSoft.Common.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Cleaner
{
    public class CleanerControlModel : ViewModelBase
    {

        private ObservableCollection<SelectableOption> _platforms;
        public ObservableCollection<SelectableOption> Platforms
        {
            get { return _platforms; }
            set { 
                _platforms = value;
                OnPropertyChanged(nameof(Platforms));
            }
        }

        private ObservableCollection<SelectableOption<FileInfo>> _pathsAnalyzed;
        public ObservableCollection<SelectableOption<FileInfo>> PathsAnalyzed
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

        public CleanerControlModel()
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
            Platforms = new ObservableCollection<SelectableOption>();
        }

        private void SetEmptyPaths()
        {
            PathsAnalyzed = new ObservableCollection<SelectableOption<FileInfo>>();
        }

    }
}
