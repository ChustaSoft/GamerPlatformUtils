using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.UI.Base;
using ChustaSoft.GamersPlatformUtils.UI.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Linker
{
    public class LinkerControlModel : ViewModelBase
    {

        private ObservableCollection<SelectablePlatform> _platforms;
        public ObservableCollection<SelectablePlatform> Platforms
        {
            get { return _platforms; }
            set { 
                _platforms = value;
                OnPropertyChanged(nameof(Platforms));
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
            Platforms = new ObservableCollection<SelectablePlatform>();
            PathsAnalyzed = new ObservableCollection<SelectableItem>(); 
        }

    }
}
