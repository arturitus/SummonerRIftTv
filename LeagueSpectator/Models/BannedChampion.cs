using Newtonsoft.Json;

namespace LeagueSpectator.Models
{
    public class BannedChampion
    {
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }
    }

}
