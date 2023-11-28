using ReactiveUI;

namespace LeagueSpectator.MVVM.Models
{
    public class MyRunes : LocalizableObject
    {
        public RuneType RuneType { get; set; }
        public Uri Tree { get; set; }
        public List<MyRune> Runes { get; }

        public MyRunes()
        {
            Runes = new List<MyRune>();
        }

        public override void LocalizeObject()
        {
            foreach (MyRune item in Runes)
            {
                item.LocalizeObject();
            }
            this.RaisePropertyChanged(nameof(RuneType));
        }
    }
}
