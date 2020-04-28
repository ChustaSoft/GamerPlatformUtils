using ChustaSoft.GamersPlatformUtils.UI.Base;
using ChustaSoft.GamersPlatformUtils.UI.Enums;

namespace ChustaSoft.GamersPlatformUtils.UI.Helpers
{
    public interface IViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewModelType viewType);
    }
}