using System.Text.Json.Serialization;

namespace LeagueSpectator.RiotApi.Models
{
    public class Account
    {
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }

        [JsonPropertyName("gameName")]
        public string GameName { get; set; }

        [JsonPropertyName("tagLine")]
        public string TagLine { get; set; }
    }
}
