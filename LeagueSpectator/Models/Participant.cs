using Avalonia.Media.Imaging;
using LeagueSpectator.Helpers;
using LeagueSpectator.IServices;
using LeagueSpectator.Services;
using Newtonsoft.Json;
using ReactiveUI;
using Splat;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LeagueSpectator.Models
{
    public class Participant : LocalizableObject
    {
        public Participant()
        {
            Bitmaps = new Bitmap[3];
            championType = ChampionType.None;
        }

        public override void LocalizeObject()
        {
            Perks.LocalizeObject();
            this.RaisePropertyChanged(nameof(ChampionType));
            this.RaisePropertyChanged(nameof(SummonerSpellType2));
            this.RaisePropertyChanged(nameof(SummonerSpellType2));
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
                m_SummonerSpellType1 = (SummonerSpellType)spell1;
                Bitmaps[1] = BitmapHelper.GetCachedBitmap(spell1, SummonerSpellType1);
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
                m_SummonerSpellType2 = (SummonerSpellType)spell2;
                Bitmaps[2] = BitmapHelper.GetCachedBitmap(spell2, SummonerSpellType2);
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
                championType = (ChampionType)championId;
                Bitmaps[0] = BitmapHelper.GetCachedBitmap(championId, championType);
            }
        }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("bot")]
        public bool Bot { get; set; }

        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }

        [JsonProperty("gameCustomizationObjects")]
        public List<object> GameCustomizationObjects { get; set; }

        [JsonProperty("perks")]
        public Perks Perks { get; set; }


        [JsonIgnore]
        public Bitmap[] Bitmaps { get; }
        [JsonIgnore]
        private ChampionType championType;
        [JsonIgnore]
        public ChampionType ChampionType => championType;
        [JsonIgnore]
        private SummonerSpellType m_SummonerSpellType1;
        [JsonIgnore]
        public SummonerSpellType SummonerSpellType1 => m_SummonerSpellType1;
        [JsonIgnore]
        private SummonerSpellType m_SummonerSpellType2;
        [JsonIgnore]
        public SummonerSpellType SummonerSpellType2 => m_SummonerSpellType2;
    }
}
