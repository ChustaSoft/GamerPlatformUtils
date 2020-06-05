using ChustaSoft.Common.Base;
using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Helpers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Cleaner
{
    public class CleanerControlViewModel : TraceableViewModelBase<CleanerControlModel>
    {

        private readonly IAnalyzerService _analyzerService;
        private readonly IFileService _fileService;
        
        private bool _multipleSelection = false;


        public bool CleanCompleted { get; private set; }
        public string CleanResultMessage { get; private set; }


        public RelayCommand AnalyseCommand { get; private set; }
        public RelayCommand CleanCommand { get; private set; }
        public RelayCommand ClearCommand { get; private set; }
        public RelayCommand ChangeAllSelectionCommand { get; private set; }
        public RelayCommand DiscardCommand { get; private set; }


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


        public CleanerControlViewModel(ILogger logger, IAnalyzerService analyzerService, IFileService fileService)
            : base(logger)
        {
            AnalyseCommand = new RelayCommand(OnAnalyze);
            CleanCommand = new RelayCommand(OnClean);
            ClearCommand = new RelayCommand(OnClear);
            ChangeAllSelectionCommand = new RelayCommand(OnChangeAllSelection);
            DiscardCommand = new RelayCommand(OnDiscard);

            _analyzerService = analyzerService;
            _fileService = fileService;

            ResetDefaultMultipleSelection();
        }


        public void Assign(ObservableCollection<SelectableOption> selectablePlatforms)
        {
            this.Model.Platforms = selectablePlatforms;
        }


        private async void OnAnalyze() 
        {
            var selectedPlatforms = Model.Platforms.GetSelected();
            var pathsAnalised = await ManageLoadingVisibility(_analyzerService.AnalyzeAsync(selectedPlatforms));
            
            this.Model.PathsAnalyzed = FileInfoMapper.Map(pathsAnalised);
            ResetDefaultMultipleSelection();
        }

        private async void OnClean()
        {
            var selectedFiles = Model.PathsAnalyzed.GetSelected();
            var cleanResult = await _fileService.Clean(selectedFiles);

            SetCleanResult(cleanResult.ToString(), true);
            ClearResultView();
        }

        private void OnClear()
        {
            ClearResultView();
        }

        private void OnChangeAllSelection() 
        {
            this.Model.ChangeAllPathsSelection(_multipleSelection);
            _multipleSelection = !_multipleSelection;
        }

        private void OnDiscard()
        {
            SetCleanResult(string.Empty, false);
        }

        private void SetCleanResult(string message, bool isCompleted)
        {
            CleanResultMessage = message;
            CleanCompleted = isCompleted;

            OnPropertyChanged(nameof(CleanResultMessage));
            OnPropertyChanged(nameof(CleanCompleted));
        }

        private void ClearResultView()
        {
            this.Model.ClearPaths();
            ResetDefaultMultipleSelection();
        }

        private void ResetDefaultMultipleSelection() 
        {
            _multipleSelection = false;
        }

        private Task<IEnumerable<FileInfo>> ManageLoadingVisibility(Task<IEnumerable<FileInfo>> analyzeTask)
        {
            this.IsLoading = true;
            analyzeTask.ContinueWith(x => this.IsLoading = false);
            return analyzeTask;
        }

    }
}
