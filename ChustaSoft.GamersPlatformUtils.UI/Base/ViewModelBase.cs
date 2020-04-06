using ChustaSoft.GamersPlatformUtils.Services;
using System.ComponentModel;

namespace ChustaSoft.GamersPlatformUtils.UI.Base
{
    public abstract class ViewModelBase<T> : INotifyPropertyChanged
    {

        private ILoadService<T> _loadService;

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


        protected ViewModelBase(ILoadService<T> loadService)
        {
            _loadService = loadService;
            LoadModel();
        }

        protected ViewModelBase(object dataContext)
        {
            ViewModel = (T)dataContext;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadModel()
        {
            _loadService.LoadEvent += OnInformationChanged;
            _loadService.Load();
        }

        private void OnInformationChanged(object sender, T viewModel)
        {
            ViewModel = viewModel;
        }

    }
}
