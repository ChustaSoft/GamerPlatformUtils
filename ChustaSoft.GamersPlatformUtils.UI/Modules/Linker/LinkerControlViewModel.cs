
using ChustaSoft.Common.Base;
using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Helpers;
using ChustaSoft.GamersPlatformUtils.UI.Models;
using ChustaSoft.GamersPlatformUtils.UI.Styles;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Linker
{
    public class LinkerControlViewModel : TraceableViewModelBase<LinkerControlModel>
    {
        private const string STEAM_PLATFORM_NAME = "steam";

        private readonly ILinkerService _linkerService;

        public RelayCommand AnalyseCommand { get; private set; }
        public RelayCommand LinkCommand { get; private set; }


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
            return selectablePlatforms.Where(x => x.Name.ToLower() == STEAM_PLATFORM_NAME);
        }

        private IEnumerable<SelectableOption> RemoveSteamPlatform(IEnumerable<SelectableOption> selectablePlatforms)
        {
            return selectablePlatforms.Where(x => !x.Name.ToLower().Contains(STEAM_PLATFORM_NAME));
        }

        private async void OnAnalyze() 
        {
            var selectedSourcePlatforms = Model.PlatformsSource.Where(x => x.Selected).Select(x => x.Name);
            var pathsAnalised = await _linkerService.SearchAsync(selectedSourcePlatforms);

            this.Model.PathsAnalyzed = new ObservableCollection<SelectableItem>( pathsAnalised.Select(x => ListItemMapper.Map(x)));
        }

        private void OnLink()
        {
            IEnumerable<GameLink> gameLinksToLink = this.Model.PathsAnalyzed.Where(x => x.Selected).Select(x => x.GameLink);
            //TODO: Get selected values and Link them to steam
        }


        #region Styles

        public static Thickness ButtonMargins => StyleConstants.HorizontalCommonMargins;

        #endregion

    }
}
