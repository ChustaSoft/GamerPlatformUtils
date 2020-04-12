﻿using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Base;
using ChustaSoft.GamersPlatformUtils.UI.Contracts;
using ChustaSoft.GamersPlatformUtils.UI.Controls;
using ChustaSoft.GamersPlatformUtils.UI.Enums;
using ChustaSoft.GamersPlatformUtils.UI.Helpers;
using ChustaSoft.GamersPlatformUtils.UI.Modules.Cleaner;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChustaSoft.GamersPlatformUtils.UI
{
    public class MainWindowViewModel : ViewModelBase<Information>, ILoadable
    {

        private readonly IViewModelFactory _viewModelFactory;
        private readonly ILoadService<Information> _informationService;

        private InformationControlViewModel _informationControlViewModel;
        public InformationControlViewModel InformationControlViewModel
        {
            get 
            {
                return _informationControlViewModel;
            }

            private set 
            {
                _informationControlViewModel = value;
                OnPropertyChanged(nameof(InformationControlViewModel));
            }
        }

        private CleanerControlViewModel _cleanerControlViewModel;
        public CleanerControlViewModel CleanerControlViewModel
        {
            get 
            {
                return _cleanerControlViewModel;
            }
            set 
            {
                _cleanerControlViewModel = value;
                OnPropertyChanged(nameof(CleanerControlViewModel));
            }
        }


        public MainWindowViewModel(IServiceProvider serviceProvider)
            : base()
        {
            
            _informationService = serviceProvider.GetService<ILoadService<Information>>();
            _viewModelFactory = new ViewModelFactory(serviceProvider, this);
            
            _informationService.LoadEvent += OnLoadCompleted;
        }


        public void OnLoad() => _informationService.Load();


        private void OnLoadCompleted(object sender, Information information)
        {
            Model = information;

            InformationControlViewModel = (InformationControlViewModel)_viewModelFactory.CreateViewModel(ViewModelType.Information);
            CleanerControlViewModel = (CleanerControlViewModel)_viewModelFactory.CreateViewModel(ViewModelType.Cleaner);
        }

    }
}
