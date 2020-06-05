
using ChustaSoft.Common.Base;
using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.Models;
using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.Domain;
using ChustaSoft.GamersPlatformUtils.Services;
using ChustaSoft.GamersPlatformUtils.UI.Helpers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Linker
{
    public class LinkerControlViewModel : TraceableViewModelBase<LinkerControlModel>
    {

        private readonly ILinkerService _linkerService;

        private bool _multipleSelection = true;


        public bool CleanCompleted { get; private set; }
        public string CleanResultMessage { get; private set; }


        public RelayCommand AnalyseCommand { get; private set; }
        public RelayCommand LinkCommand { get; private set; }
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

        public LinkerControlViewModel(ILogger logger, ILinkerService linkerService)
            : base(logger)
        {
            AnalyseCommand = new RelayCommand(OnAnalyze);
            LinkCommand = new RelayCommand(OnLink);
            ClearCommand = new RelayCommand(OnClear);
            ChangeAllSelectionCommand = new RelayCommand(OnChangeAllSelection);
            DiscardCommand = new RelayCommand(OnDiscard);

            _linkerService = linkerService;
        }

        public void Assign(IEnumerable<SelectableOption> selectablePlatforms)
        {
            this.Model.PlatformsSource = new ObservableCollection<SelectableOption>(RemoveSteamPlatform(selectablePlatforms));
            this.Model.PlatformsDestination = new ObservableCollection<SelectableOption>(SelectSteamPlatform(selectablePlatforms));
        }

        private async void OnAnalyze() 
        {
            var selectedSourcePlatforms = Model.PlatformsSource.GetSelected();

            var pathsAnalised = await ManageLoadingVisibility(_linkerService.SearchAsync(selectedSourcePlatforms));

            this.Model.PathsAnalyzed = GameLinkMapper.Map(pathsAnalised);

        }

        private void OnLink()
        {
            var gameLinksToLink = this.Model.PathsAnalyzed.GetSelected();
            //TODO: Get selected values and Link them to steam
        }

        private void OnClear()
        {
            ClearResultView();
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

        private void OnChangeAllSelection()
        {
            this.Model.ChangeAllPathsSelection(_multipleSelection);
            _multipleSelection = !_multipleSelection;
        }

        private void OnDiscard()
        {
            SetCleanResult(string.Empty, false);
        }

        private void ResetDefaultMultipleSelection()
        {
            _multipleSelection = false;
        }

        private Task<IEnumerable<GameLink>> ManageLoadingVisibility(Task<IEnumerable<GameLink>> analyzeTask)
        {
            this.IsLoading = true;
            analyzeTask.ContinueWith(x => this.IsLoading = false);
            return analyzeTask;
        }

        private IEnumerable<SelectableOption> SelectSteamPlatform(IEnumerable<SelectableOption> selectablePlatforms)
        {
            return selectablePlatforms.Where(x => x.Name.Equals(SteamConstants.PLATFORM_NAME));
        }

        private IEnumerable<SelectableOption> RemoveSteamPlatform(IEnumerable<SelectableOption> selectablePlatforms)
        {
            return selectablePlatforms.Where(x => !x.Name.Contains(SteamConstants.PLATFORM_NAME));
        }

    }
}
