using System.Text.Json.Serialization;

namespace LeagueSpectator.RiotApi.Models
{
    public class Participant
    {
        [JsonPropertyName("teamId")]
        public TeamId TeamId { get; set; }

        [JsonPropertyName("spell1Id")]
        public int Spell1Id { get; set; }

        [JsonPropertyName("spell2Id")]
        public int Spell2Id { get; set; }

        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }

        [JsonPropertyName("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }

        [JsonPropertyName("bot")]
        public bool Bot { get; set; }

        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }

        [JsonPropertyName("gameCustomizationObjects")]
        public List<object> GameCustomizationObjects { get; set; }

        [JsonPropertyName("perks")]
        public Perks Perks { get; set; }
    }

    public enum TeamId : int
    {
        BlueTeam = 100,
        RedTeam = 200
    }
}
