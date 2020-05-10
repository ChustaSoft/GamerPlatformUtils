using ChustaSoft.Common.Base;
using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Helpers;
using ChustaSoft.GamersPlatformUtils.UI.Styles;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Cleaner
{
    public class CleanerControlViewModel : TraceableViewModelBase<CleanerControlModel>
    {

        private readonly IAnalyzerService _analyzerService;

        public RelayCommand AnalyseCommand { get; private set; }
        public RelayCommand CleanCommand { get; private set; }


        public CleanerControlViewModel(ILogger logger, IAnalyzerService analyzerService)
            : base(logger)
        {
            AnalyseCommand = new RelayCommand(OnAnalyze);
            CleanCommand = new RelayCommand(OnClean);

            _analyzerService = analyzerService;
        }


        public void Assign(ObservableCollection<SelectableOption> selectablePlatforms)
        {
            this.Model.Platforms = selectablePlatforms;
        }


        private async void OnAnalyze() 
        {
            var selectedPlatforms = Model.Platforms.Where(x => x.Selected).Select(x => x.Name);
            var pathsAnalised = await _analyzerService.AnalyzeAsync(selectedPlatforms);

            this.Model.PathsAnalyzed = FileInfoMapper.Map(pathsAnalised);
        }

        private void OnClean()
        {
            //TODO: Get selected values and remove from the system
        }


        #region Styles

        public static Thickness ButtonMargins => StyleConstants.HorizontalCommonMargins;

        #endregion

    }
}
