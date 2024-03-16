using ReactiveUI;
using SummonerRiftTv.MVVM.Helpers;
using SummonerRiftTv.MVVM.Models;
using SummonerRiftTv.RiotApi.Models;

namespace SummonerRiftTv.MVVM.DTOs
{
    public class BannedChampionDTO : LocalizableObject
    {
        private int championId;
        private Uri bitmap;
        private ChampionType championType;

        public int ChampionId
        {
            get => championId;
            set
            {
                championId = value;
                bitmap = LeagueAssetResolver.GetUri(championId, ChampionType);
                championType = (ChampionType)championId;
            }
        }
        public TeamId TeamId { get; set; }

        public int PickTurn { get; set; }

        public Uri Bitmap => bitmap;

        public ChampionType ChampionType => championType;

        public override void LocalizeObject()
        {
            this.RaisePropertyChanged(nameof(ChampionType));
        }

        public static implicit operator BannedChampionDTO(BannedChampion bannedChampion)
        {
            return new BannedChampionDTO()
            {
                TeamId = bannedChampion.TeamId,
                ChampionId = bannedChampion.ChampionId,
                PickTurn = bannedChampion.PickTurn
            };
        }
    }
}
