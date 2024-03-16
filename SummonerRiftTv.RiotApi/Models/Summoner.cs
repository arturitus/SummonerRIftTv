using System.Text.Json.Serialization;

namespace SummonerRiftTv.RiotApi.Models
{
    public class Summoner
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonPropertyName("revisionDate")]
        public long RevisionDate { get; set; }

        [JsonPropertyName("summonerLevel")]
        public long SummonerLevel { get; set; }
    }
}
