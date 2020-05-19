
using ChustaSoft.Common.Base;
using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Helpers;
using ChustaSoft.GamersPlatformUtils.UI.Styles;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Linker
{
    public class LinkerControlViewModel : TraceableViewModelBase<LinkerControlModel>
    {        
        private readonly ILinkerService _linkerService;

        public RelayCommand AnalyseCommand { get; private set; }
        public RelayCommand LinkCommand { get; private set; }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public LinkerControlViewModel(ILogger logger, ILinkerService linkerService)
            : base(logger)
        {
            AnalyseCommand = new RelayCommand(OnAnalyze);
            LinkCommand = new RelayCommand(OnLink);

            _linkerService = linkerService;
        }

        public void Assign(IEnumerable<SelectableOption> selectablePlatforms)
        {
            this.Model.PlatformsSource = new ObservableCollection<SelectableOption>(RemoveSteamPlatform(selectablePlatforms));

            this.Model.PlatformsDestination = new ObservableCollection<SelectableOption>(SelectSteamPlatform(selectablePlatforms));
        }

        private IEnumerable<SelectableOption> SelectSteamPlatform(IEnumerable<SelectableOption> selectablePlatforms)
        {
            return selectablePlatforms.Where(x => x.Name.ToLower() == SteamConstants.PLATFORM_NAME.ToLower());
        }

        private IEnumerable<SelectableOption> RemoveSteamPlatform(IEnumerable<SelectableOption> selectablePlatforms)
        {
            return selectablePlatforms.Where(x => !x.Name.ToLower().Contains(SteamConstants.PLATFORM_NAME.ToLower()));
        }

        private async void OnAnalyze() 
        {
            this.IsLoading = true;

            var selectedSourcePlatforms = Model.PlatformsSource.Where(x => x.Selected).Select(x => x.Name);

            var pathsAnalised = await ManageLoadingVisibility(_linkerService.SearchAsync(selectedSourcePlatforms));

            this.Model.PathsAnalyzed = new ObservableCollection<SelectableOption<GameLink>>( pathsAnalised.Select(x => GameLinkMapper.Map(x)));

        }

        private void OnLink()
        {
            IEnumerable<GameLink> gameLinksToLink = this.Model.PathsAnalyzed.Where(x => x.Selected).Select(x => x.Value);
            //TODO: Get selected values and Link them to steam
        }

        private Task<IEnumerable<GameLink>> ManageLoadingVisibility(Task<IEnumerable<GameLink>> task)
        {
            this.IsLoading = true;
            task.ContinueWith(x => this.IsLoading = false);
            return task;
        }


        #region Styles

        public static Thickness ButtonMargins => StyleConstants.HorizontalCommonMargins;

        #endregion

    }
}
