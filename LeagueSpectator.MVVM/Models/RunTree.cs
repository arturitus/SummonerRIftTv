using ReactiveUI;

namespace LeagueSpectator.MVVM.Models
{
    public class RunTree : LocalizableObject
    {
        public RuneType RuneType { get; set; }
        public Uri Tree { get; set; }
        public List<Rune> Runes { get; }

        public RunTree()
        {
            Runes = new List<Rune>();
        }

        public override void LocalizeObject()
        {
            foreach (Rune item in Runes)
            {
                item.LocalizeObject();
            }
            this.RaisePropertyChanged(nameof(RuneType));
        }
    }
}
