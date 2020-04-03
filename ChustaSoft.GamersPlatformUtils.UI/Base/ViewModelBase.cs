using System.ComponentModel;

namespace ChustaSoft.GamersPlatformUtils.UI.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        //private T _viewModel;
        //public T ViewModel 
        //{
        //    get 
        //    { 
        //        return _viewModel; 
        //    }
        //    set 
        //    { 
        //        _viewModel = value;
        //        OnPropertyChanged(nameof(ViewModel));
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;


        public ViewModelBase() { }


        public void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
