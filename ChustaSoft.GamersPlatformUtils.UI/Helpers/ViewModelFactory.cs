using ChustaSoft.Common.Base;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Controls;
using ChustaSoft.GamersPlatformUtils.UI.Enums;
using ChustaSoft.GamersPlatformUtils.UI.Modules.Cleaner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.GamersPlatformUtils.UI.Helpers
{
    public class ViewModelFactory : IViewModelFactory
    {

        private IDictionary<ViewModelType, ViewModelBase> _viewModels = new Dictionary<ViewModelType, ViewModelBase>();

        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly IServiceProvider _serviceProvider;

        private readonly ILogger _logger;


        public ViewModelFactory(IServiceProvider serviceProvider, ILogger logger, MainWindowViewModel mainWindowViewModel)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _mainWindowViewModel = mainWindowViewModel;
        }


        public ViewModelBase CreateViewModel(ViewModelType viewType)
        {
            switch (viewType)
            {
                case ViewModelType.Information:
                    return GetInformationControlViewModel();
                case ViewModelType.Cleaner:
                    return GetCleanerControlViewModel();
                case ViewModelType.Linker:
                    return null;
                default:
                    return _mainWindowViewModel;
            }
        }


        private ViewModelBase GetInformationControlViewModel()
        {
            if (!_viewModels.ContainsKey(ViewModelType.Information))
            {
                var viewModel = new InformationControlViewModel(_logger);

                viewModel.Model = _mainWindowViewModel?.Model ?? null;

                _viewModels.Add(ViewModelType.Information, viewModel);
            }

            return _viewModels[ViewModelType.Information];
        }

        private ViewModelBase GetCleanerControlViewModel()
        {
            if (!_viewModels.ContainsKey(ViewModelType.Cleaner)) 
            {
                var viewModel = new CleanerControlViewModel(_logger, _serviceProvider.GetService<IAnalyzerService>());

                if(_mainWindowViewModel.Model?.Platforms != null)
                    viewModel.Assign(_mainWindowViewModel.Model.Platforms.Select(x => PlatformMapper.Map(x)));

                _viewModels.Add(ViewModelType.Cleaner, viewModel);
            }

            return _viewModels[ViewModelType.Cleaner];
        }

    }
}
