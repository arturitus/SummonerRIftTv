using LeagueSpectator.DTOs;
using LeagueSpectator.MVVM.Helpers;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.RiotApi.Models;
using Newtonsoft.Json;
using ReactiveUI;

namespace LeagueSpectator.MVVM.DTOs
{
    public class ParticipantDTO : LocalizableObject
    {
        public ParticipantDTO()
        {
            Bitmaps = new Uri[3];
            championType = ChampionType.None;
        }

        public override void LocalizeObject()
        {
            Perks.LocalizeObject();
            this.RaisePropertyChanged(nameof(ChampionType));
            this.RaisePropertyChanged(nameof(SummonerSpellType1));
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
                Bitmaps[1] = LeagueAssetResolver.GetBitmap(spell1, SummonerSpellType1);
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
                Bitmaps[2] = LeagueAssetResolver.GetBitmap(spell2, SummonerSpellType2);
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
                Bitmaps[0] = LeagueAssetResolver.GetBitmap(championId, championType);
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
        public PerksDTO Perks { get; set; }


        [JsonIgnore]
        public Uri[] Bitmaps { get; }
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

        public static implicit operator ParticipantDTO(Participant participant)
        {
            return new ParticipantDTO()
            {
                Bot = participant.Bot,
                ChampionId = participant.ChampionId,
                Perks = participant.Perks,
                GameCustomizationObjects = participant.GameCustomizationObjects,
                ProfileIconId = participant.ProfileIconId,
                Spell1Id = participant.Spell1Id,
                Spell2Id = participant.Spell2Id,
                SummonerId = participant.SummonerId,
                SummonerName = participant.SummonerName,
                TeamId = participant.TeamId
            };
        }
    }
}
