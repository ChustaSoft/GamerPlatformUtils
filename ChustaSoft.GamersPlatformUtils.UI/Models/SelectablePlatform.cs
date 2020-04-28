using ChustaSoft.GamersPlatformUtils.UI.Base;

namespace ChustaSoft.GamersPlatformUtils.UI.Models
{
    public class SelectablePlatform : ViewModelBase
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

    }
}
