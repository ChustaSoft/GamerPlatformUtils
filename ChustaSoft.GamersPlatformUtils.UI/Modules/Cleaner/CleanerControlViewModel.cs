using ChustaSoft.GamersPlatformUtils.Abstractions;
using ChustaSoft.GamersPlatformUtils.UI.Base;
using ChustaSoft.GamersPlatformUtils.UI.Helpers;
using ChustaSoft.GamersPlatformUtils.UI.Styles;
using System.Collections.Generic;
using System.Windows;

namespace ChustaSoft.GamersPlatformUtils.UI.Modules.Cleaner
{
    public class CleanerControlViewModel : ViewModelBase<IEnumerable<IPlatform>>
    {

        public RelayCommand AnalyseCommand { get; private set; }
        public RelayCommand CleanCommand { get; private set; }


        public CleanerControlViewModel()
            : base()
        {
            AnalyseCommand = new RelayCommand(OnAnalyze);
            CleanCommand = new RelayCommand(OnClean);
        }


        private void OnAnalyze() 
        { 
        
        }

        private void OnClean()
        {
            
        }


        #region Styles

        public static Thickness ButtonMargins => StyleConstants.HorizontalCommonMargins;

        #endregion

    }
}
