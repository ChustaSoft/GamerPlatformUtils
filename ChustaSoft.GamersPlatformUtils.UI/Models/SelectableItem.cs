using ChustaSoft.Common.Base;
using ChustaSoft.GamersPlatformUtils.Abstractions;

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
