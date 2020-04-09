using System.ComponentModel;

namespace ChustaSoft.GamersPlatformUtils.UI.Base
{
    public abstract class ViewModelBase<T> : INotifyPropertyChanged
    {

        private T _viewModel;
        
        public T ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
                OnPropertyChanged(nameof(ViewModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public ViewModelBase() { }

        protected ViewModelBase(object dataContext)
        {
            ViewModel = (T)dataContext;
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
