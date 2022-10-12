using Avalonia.Media.Imaging;
using LeagueSpectator.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueSpectator.Models
{
    public class BannedChampion
    {
        private int championId;
        [JsonProperty("championId")]
        public int ChampionId
        {
            get => championId;
            set
            {
                championId = value;
                Bitmap = BitmapHelper.GetChampion(championId).Result;
            }
        }


        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }

        [JsonIgnore]
        public Bitmap? Bitmap { get; private set; }
    }
}
