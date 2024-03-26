using ReactiveUI;
using SummonerRiftTv.MVVM.Helpers;
using SummonerRiftTv.MVVM.Models;
using SummonerRiftTv.RiotApi.Models;

namespace SummonerRiftTv.MVVM.DTOs
{
    public class LeagueItemDTO : LocalizableObject
    {
        private Tier m_Tier;

        public QueueType QueueType { get; set; }

        public Tier Tier
        {
            get => m_Tier;
            set
            {
                m_Tier = value;
                Bitmap = LeagueAssetResolver.GetUri((int)m_Tier, m_Tier);
            }
        }

        public Rank Rank { get; set; }

        public int LeaguePoints { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public Uri Bitmap { get; set; }

        public bool IsRankVisible
        {
            get
            {
                return Tier > Tier.Master;
            }
        }

        public override void LocalizeObject()
        {
            this.RaisePropertyChanged(nameof(Tier));
        }

        public static implicit operator LeagueItemDTO(LeagueItem leagueItem)
        {
            if(leagueItem is null)
            {
                return null;
            }
            return new LeagueItemDTO
            {
                QueueType = Enum.Parse<QueueType>(leagueItem.QueueType),
                Tier = Enum.Parse<Tier>(leagueItem.Tier, true),
                Rank = Enum.Parse<Rank>(leagueItem.Rank),
                LeaguePoints = leagueItem.LeaguePoints,
                Wins = leagueItem.Wins,
                Losses = leagueItem.Losses
            };
        }
    }
}
