using ChustaSoft.GamersPlatformUtils.UI.Base;
using ChustaSoft.GamersPlatformUtils.UI.Models;
using System.Collections.ObjectModel;
using System.IO;

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

        private ObservableCollection<FileInfo> _pathsAnalyzed;
        public ObservableCollection<FileInfo> PathsAnalyzed
        {
            get { return _pathsAnalyzed; }
            set
            {
                _pathsAnalyzed = value;
                OnPropertyChanged(nameof(PathsAnalyzed));
            }
        }


        public CleanerControlModel() 
        {
            Platforms = new ObservableCollection<SelectableOption>();
            PathsAnalyzed = new ObservableCollection<FileInfo>(); 
        }

    }
}
