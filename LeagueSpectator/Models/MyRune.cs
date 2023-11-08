using Avalonia.Media.Imaging;
using ReactiveUI;

namespace LeagueSpectator.Models
{
    public class MyRune : LocalizableObject
    {
        public RuneType RuneType { get; set; }
        public Bitmap Bitmap { get; set; }

        public override void LocalizeObject()
        {
            this.RaisePropertyChanged(nameof(RuneType));
        }
    }
}
