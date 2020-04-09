using System.ComponentModel;

namespace ChustaSoft.GamersPlatformUtils.UI.Base
{

    public abstract class ViewModelBase : INotifyPropertyChanged 
    {

        public event PropertyChangedEventHandler PropertyChanged;


        protected ViewModelBase() { }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


    public abstract class ViewModelBase<T> : ViewModelBase
    {

        private T _model;
        
        public T Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

    }
}
