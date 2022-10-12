using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSpectator.Models
{
    public class MyRunes
    {
        public RuneType RuneType { get; set; }
        public Bitmap? Tree { get; set; }
        public List<MyRune> Runes { get; }

        public MyRunes()
        {
            Runes = new List<MyRune>();
        }
    }
}
