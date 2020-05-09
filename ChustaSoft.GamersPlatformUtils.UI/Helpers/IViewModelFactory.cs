using ChustaSoft.Common.Base;
using ChustaSoft.GamersPlatformUtils.UI.Enums;

namespace ChustaSoft.GamersPlatformUtils.UI.Helpers
{
    public interface IViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewModelType viewType);
    }
}