using System.Text.Json.Serialization;

namespace LeagueSpectator.RiotApi.Models
{
    public class Perks
    {
        [JsonPropertyName("perkStyle")]
        public int PerkStyle { get; set; }

        [JsonPropertyName("perkSubStyle")]
        public int PerkSubStyle { get; set; }

        [JsonPropertyName("perkIds")]
        public List<int> PerkIds { get; set; }
    }
}
