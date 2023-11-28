using Avalonia.Media.Imaging;
using LeagueSpectator.Helpers;
using LeagueSpectator.Models;
using LeagueSpectator.RiotApi.Models;
using Newtonsoft.Json;
using ReactiveUI;

namespace LeagueSpectator.DTOs
{
    public class BannedChampionDTO : LocalizableObject
    {
        private int championId;
        [JsonProperty("championId")]
        public int ChampionId
        {
            get => championId;
            set
            {
                championId = value;
                bitmap = BitmapHelper.GetCachedBitmap(championId, ChampionType);
                championType = (ChampionType)championId;
            }
        }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }

        [JsonIgnore]
        private Bitmap bitmap;
        [JsonIgnore]
        public Bitmap Bitmap => bitmap;

        [JsonIgnore]
        private ChampionType championType;

        [JsonIgnore]
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
