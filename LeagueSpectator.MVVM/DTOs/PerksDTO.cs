using LeagueSpectator.MVVM.Helpers;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.RiotApi.Models;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("perkStyle")]
        public int PerkStyle
        {
            get => perkStyle;
            set
            {
                perkStyle = value;
                MyRunes[0].RuneType = (RuneType)perkStyle;
                MyRunes[0].Tree = LeagueAssetResolver.GetUri(perkStyle, MyRunes[0].RuneType);
            }
        }
        private int perkSubStyle;

        [JsonPropertyName("perkSubStyle")]
        public int PerkSubStyle
        {
            get => perkSubStyle;
            set
            {
                perkSubStyle = value;
                MyRunes[1].RuneType = (RuneType)perkSubStyle;
                MyRunes[1].Tree = LeagueAssetResolver.GetUri(perkSubStyle, MyRunes[1].RuneType);
            }
        }
        [JsonIgnore]
        public MyRunes[] MyRunes { get; }

        private List<int> perkIds;
        [JsonPropertyName("perkIds")]
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
                            MyRunes[1].Runes.Add(new MyRune() { Bitmap = LeagueAssetResolver.GetUri(id, (RuneType)id), RuneType = (RuneType)id });
                        }
                        else if (MyRunes[1].Runes.Count >= 2 && MyRunes[2].Runes.Count < 3)
                        {
                            MyRunes[2].Runes.Add(new MyRune() { Bitmap = LeagueAssetResolver.GetUri(id, (RuneType)id), RuneType = (RuneType)id });
                        }
                        else
                        {
                            MyRunes[0].Runes.Add(new MyRune() { Bitmap = LeagueAssetResolver.GetUri(id, (RuneType)id), RuneType = (RuneType)id });
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
