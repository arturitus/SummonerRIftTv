using LeagueSpectator.MVVM.Models;
using System.Collections.Frozen;

namespace LeagueSpectator.MVVM.IViewModels
{
    public interface IMainWindowViewModel
    {
        public event Action<bool> IsBusy;
        public event Action<FrozenSet<InfoDialogKeys>> InfoDialog;
        public event Action<ErrorDialogFormat> ErrorDialog;
    }
}
