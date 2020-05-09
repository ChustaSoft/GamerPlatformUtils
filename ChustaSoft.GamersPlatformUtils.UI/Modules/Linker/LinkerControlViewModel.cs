
using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Base;
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


        public void Assign(IEnumerable<SelectablePlatform> selectablePlatforms)
        {
            this.Model.Platforms = new ObservableCollection<SelectablePlatform>(RemoveSteamPlatform(selectablePlatforms));
        }

        private IEnumerable<SelectablePlatform> RemoveSteamPlatform(IEnumerable<SelectablePlatform> selectablePlatforms)
        {
            return selectablePlatforms.Where(x => !x.Name.ToLower().Contains(STEAM_PLATFORM_NAME));
        }

        private async void OnAnalyze() 
        {
            var selectedPlatforms = Model.Platforms.Where(x => x.Selected).Select(x => x.Name);
            var pathsAnalised = await _linkerService.SearchAsync(selectedPlatforms);

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
