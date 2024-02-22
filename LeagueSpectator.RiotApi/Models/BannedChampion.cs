using System.Text.Json.Serialization;

namespace LeagueSpectator.RiotApi.Models
{
    public class BannedChampion
    {
        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }

        [JsonPropertyName("teamId")]
        public TeamId TeamId { get; set; }

        [JsonPropertyName("pickTurn")]
        public int PickTurn { get; set; }
    }
}
