using ReactiveUI;

namespace LeagueSpectator.MVVM.Models
{
    public abstract class LocalizableObject : ReactiveObject
    {
        public abstract void LocalizeObject();
    }
}
