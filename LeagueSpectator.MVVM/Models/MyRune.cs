using ReactiveUI;

namespace LeagueSpectator.MVVM.Models
{
    public class MyRune : LocalizableObject
    {
        public RuneType RuneType { get; set; }
        public Uri Bitmap { get; set; }

        public override void LocalizeObject()
        {
            this.RaisePropertyChanged(nameof(RuneType));
        }
    }
}
