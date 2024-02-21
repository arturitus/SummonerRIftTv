using LeagueSpectator.DTOs;
using LeagueSpectator.MVVM.Helpers;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.RiotApi.Models;
using ReactiveUI;
using System.Text.Json.Serialization;

namespace LeagueSpectator.MVVM.DTOs
{
    public class ParticipantDTO : LocalizableObject
    {
        private int spell1;
        private int spell2;
        private int championId;
        private ChampionType championType;
        private SummonerSpellType m_SummonerSpellType1;
        private SummonerSpellType m_SummonerSpellType2;

        public int TeamId { get; set; }

        public int Spell1Id
        {
            get => spell1;
            set
            {
                spell1 = value;
                m_SummonerSpellType1 = (SummonerSpellType)spell1;
                Bitmaps[1] = LeagueAssetResolver.GetUri(spell1, SummonerSpellType1);
            }
        }

        public int Spell2Id
        {
            get => spell2;
            set
            {
                spell2 = value;
                m_SummonerSpellType2 = (SummonerSpellType)spell2;
                Bitmaps[2] = LeagueAssetResolver.GetUri(spell2, SummonerSpellType2);
            }
        }

        public int ChampionId
        {
            get => championId;
            set
            {
                championId = value;
                championType = (ChampionType)championId;
                Bitmaps[0] = LeagueAssetResolver.GetUri(championId, championType);
            }
        }

        public int ProfileIconId { get; set; }

        public string SummonerName { get; set; }

        public bool Bot { get; set; }

        public string SummonerId { get; set; }

        public List<object> GameCustomizationObjects { get; set; }

        public PerksDTO Perks { get; set; }

        public Uri[] Bitmaps { get; }

        public ChampionType ChampionType => championType;

        public SummonerSpellType SummonerSpellType1 => m_SummonerSpellType1;

        public SummonerSpellType SummonerSpellType2 => m_SummonerSpellType2;


        public ParticipantDTO()
        {
            Bitmaps = new Uri[3];
            championType = ChampionType.NoneChampion;
        }

        public override void LocalizeObject()
        {
            Perks.LocalizeObject();
            this.RaisePropertyChanged(nameof(ChampionType));
            this.RaisePropertyChanged(nameof(SummonerSpellType1));
            this.RaisePropertyChanged(nameof(SummonerSpellType2));
        }       

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
