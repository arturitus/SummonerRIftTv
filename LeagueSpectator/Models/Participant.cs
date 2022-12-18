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
            SummonerSpellTypes = new SummonerSpellType[2];
            championType = ChampionType.None;
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
                SummonerSpellTypes[0] = (SummonerSpellType)spell1;
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
                SummonerSpellTypes[1] = (SummonerSpellType)spell2;
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
                championType = (ChampionType)championId;
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

        [JsonIgnore]
        private ChampionType championType;

        [JsonIgnore]
        public ChampionType ChampionType => championType;

        [JsonIgnore]
        public SummonerSpellType[] SummonerSpellTypes { get; }
    }
}
