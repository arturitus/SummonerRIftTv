using Newtonsoft.Json;

namespace LeagueSpectator.RiotApi.Models
{
    public class Participant
    {
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("spell1Id")]
        public int Spell1Id { get; set; }

        [JsonProperty("spell2Id")]
        public int Spell2Id { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("bot")]
        public bool Bot { get; set; }

        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }

        [JsonProperty("gameCustomizationObjects")]
        public List<object> GameCustomizationObjects { get; set; }

        [JsonProperty("perks")]
        public Perks Perks { get; set; }
    }
}
