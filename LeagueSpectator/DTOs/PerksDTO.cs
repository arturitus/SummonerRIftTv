using LeagueSpectator.Helpers;
using LeagueSpectator.Models;
using LeagueSpectator.RiotApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueSpectator.DTOs
{
    public class PerksDTO
    {
        public PerksDTO()
        {
            MyRunes = new MyRunes[3];
            for (int i = 0; i < MyRunes.Length; i++)
            {
                MyRunes[i] = new MyRunes();
            }
        }

        private int perkStyle;
        [JsonProperty("perkStyle")]
        public int PerkStyle
        {
            get => perkStyle;
            set
            {
                perkStyle = value;
                MyRunes[0].RuneType = (RuneType)perkStyle;
                MyRunes[0].Tree = BitmapHelper.GetCachedBitmap(perkStyle, MyRunes[0].RuneType);
            }
        }
        private int perkSubStyle;

        [JsonProperty("perkSubStyle")]
        public int PerkSubStyle
        {
            get => perkSubStyle;
            set
            {
                perkSubStyle = value;
                MyRunes[1].RuneType = (RuneType)perkSubStyle;
                MyRunes[1].Tree = BitmapHelper.GetCachedBitmap(perkSubStyle, MyRunes[1].RuneType);
            }
        }
        [JsonIgnore]
        public MyRunes[] MyRunes { get; }

        private List<int> perkIds;
        [JsonProperty("perkIds")]
        public List<int> PerkIds
        {
            get => perkIds;
            set
            {
                perkIds = value;
                if (perkIds != null)
                {
                    foreach (int id in perkIds)
                    {
                        if (MyRunes[0].Runes.Count >= 4 && MyRunes[1].Runes.Count < 2)
                        {
                            MyRunes[1].Runes.Add(new MyRune() { Bitmap = BitmapHelper.GetCachedBitmap(id, (RuneType)id), RuneType = (RuneType)id });
                        }
                        else if (MyRunes[1].Runes.Count >= 2 && MyRunes[2].Runes.Count < 3)
                        {
                            MyRunes[2].Runes.Add(new MyRune() { Bitmap = BitmapHelper.GetCachedBitmap(id, (RuneType)id), RuneType = (RuneType)id });
                        }
                        else
                        {
                            MyRunes[0].Runes.Add(new MyRune() { Bitmap = BitmapHelper.GetCachedBitmap(id, (RuneType)id), RuneType = (RuneType)id });
                        }
                    }
                }
            }
        }

        public void LocalizeObject()
        {
            foreach (MyRunes rune in MyRunes)
            {
                rune.LocalizeObject();
            }
        }

        public static implicit operator PerksDTO(Perks perks)
        {
            return new PerksDTO()
            {
                PerkIds = perks.PerkIds,
                PerkStyle = perks.PerkStyle,
                PerkSubStyle = perks.PerkSubStyle
            };
        }
    }
}
