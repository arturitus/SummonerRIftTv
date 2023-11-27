using Avalonia.Media.Imaging;
using ReactiveUI;
using System.Collections.Generic;

namespace LeagueSpectator.Models
{
    public class MyRunes : LocalizableObject
    {
        public RuneType RuneType { get; set; }
        public Bitmap Tree { get; set; }
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
