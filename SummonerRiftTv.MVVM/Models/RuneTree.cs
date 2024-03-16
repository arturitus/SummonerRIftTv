using ReactiveUI;

namespace SummonerRiftTv.MVVM.Models
{
    public class RuneTree : LocalizableObject
    {
        public RuneType RuneType { get; set; }
        public Uri Tree { get; set; }
        public List<Rune> Runes { get; }

        public RuneTree()
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
