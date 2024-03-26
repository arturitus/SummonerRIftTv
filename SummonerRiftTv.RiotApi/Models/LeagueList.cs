using System.Text.Json.Serialization;

namespace SummonerRiftTv.RiotApi.Models
{
    public class LeagueList
    {

        [JsonPropertyName("tier")]
        public string Tier { get; set; }

        [JsonPropertyName("leagueId")]
        public string LeagueId { get; set; }

        [JsonPropertyName("queue")]
        public string Queue { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("entries")]
        public LeagueItem[] LeagueItems { get; set; }
    }

}
