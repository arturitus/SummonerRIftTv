using ReactiveUI;

namespace LeagueSpectator.MVVM.Models
{
    public class Rune : LocalizableObject
    {
        public RuneType RuneType { get; set; }
        public Uri Bitmap { get; set; }

        public override void LocalizeObject()
        {
            this.RaisePropertyChanged(nameof(RuneType));
        }
    }
}
