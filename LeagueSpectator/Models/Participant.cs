using Avalonia.Media.Imaging;
using LeagueSpectator.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueSpectator.Models
{
    public class Participant
    {
        public Participant()
        {
            Bitmaps = new Bitmap[3];
        }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        private int spell1;
        [JsonProperty("spell1Id")]
        public int Spell1Id
        {
            get => spell1;
            set
            {
                spell1 = value;
                Bitmaps[1] = BitmapHelper.GetSummonerSpell(spell1);
            }
        }

        private int spell2;
        [JsonProperty("spell2Id")]
        public int Spell2Id
        {
            get => spell2;
            set
            {
                spell2 = value;
                Bitmaps[2] = BitmapHelper.GetSummonerSpell(spell2);
            }
        }

        private int championId;
        [JsonProperty("championId")]
        public int ChampionId
        {
            get => championId;
            set
            {
                championId = value;
                Bitmaps[0] = BitmapHelper.GetChampion(championId).Result;
            }
        }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("summonerName")]
        public string? SummonerName { get; set; }

        [JsonProperty("bot")]
        public bool Bot { get; set; }

        [JsonProperty("summonerId")]
        public string? SummonerId { get; set; }

        [JsonProperty("gameCustomizationObjects")]
        public List<object>? GameCustomizationObjects { get; set; }

        [JsonProperty("perks")]
        public Perks? Perks { get; set; }

        [JsonIgnore]
        public Bitmap[] Bitmaps { get; }
    }
}
