using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueSpectator.Models
{
    public class Perks
    {
        [JsonProperty("perkIds")]
        public List<int>? PerkIds { get; set; }

        [JsonProperty("perkStyle")]
        public int PerkStyle { get; set; }

        [JsonProperty("perkSubStyle")]
        public int PerkSubStyle { get; set; }
    }

}
