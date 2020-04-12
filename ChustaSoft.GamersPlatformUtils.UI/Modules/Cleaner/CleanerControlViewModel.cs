using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Base;
using ChustaSoft.GamersPlatformUtils.UI.Helpers;
using ChustaSoft.GamersPlatformUtils.UI.Models;
using ChustaSoft.GamersPlatformUtils.UI.Styles;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Cleaner
{
    public class CleanerControlViewModel : ViewModelBase<CleanerControlModel>
    {

        private readonly IAnalyzerService _analyzerService;

        public RelayCommand AnalyseCommand { get; private set; }
        public RelayCommand CleanCommand { get; private set; }


        public CleanerControlViewModel(IAnalyzerService analyzerService)
            : base()
        {
            AnalyseCommand = new RelayCommand(OnAnalyze);
            CleanCommand = new RelayCommand(OnClean);

            _analyzerService = analyzerService;
        }


        public void Assign(IEnumerable<SelectablePlatform> selectablePlatforms)
        {
            this.Model.Platforms = new ObservableCollection<SelectablePlatform>(selectablePlatforms);
        }


        private async void OnAnalyze() 
        {
            var selectedPlatforms = Model.Platforms.Where(x => x.Selected).Select(x => x.Name);
            var pathsAnalised = await _analyzerService.AnalyzeAsync(selectedPlatforms);
            
            this.Model.PathsAnalyzed = new ObservableCollection<FileInfo>(pathsAnalised);
        }

        private void OnClean()
        {

        }


        #region Styles

        public static Thickness ButtonMargins => StyleConstants.HorizontalCommonMargins;

        #endregion

    }
}
