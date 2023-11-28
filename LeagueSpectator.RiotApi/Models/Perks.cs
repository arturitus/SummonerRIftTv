using Newtonsoft.Json;

namespace LeagueSpectator.RiotApi.Models
{
    public class Perks
    {
        [JsonProperty("perkStyle")]
        public int PerkStyle { get; set; }

        [JsonProperty("perkSubStyle")]
        public int PerkSubStyle { get; set; }

        [JsonProperty("perkIds")]
        public List<int> PerkIds { get; set; }
    }
}
