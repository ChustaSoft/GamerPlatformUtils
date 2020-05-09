using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.UI.Base;

namespace ChustaSoft.GamersPlatformUtils.UI.Models
{
    public class SelectableItem : ViewModelBase
    {

        private bool _Selected;
        public bool Selected
        {
            get { return _Selected; }
            set
            {
                _Selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private GameLink _gameLink;
        public GameLink GameLink
        {
            get { return _gameLink; }
            set
            {
                _gameLink = value;
                OnPropertyChanged(nameof(GameLink));
            }
        }

    }
}
