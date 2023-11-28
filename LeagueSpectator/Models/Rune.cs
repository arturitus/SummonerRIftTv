using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueSpectator.Models
{
    public class Rune
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("majorChangePatchVersion")]
        public string MajorChangePatchVersion { get; set; }

        [JsonProperty("tooltip")]
        public string Tooltip { get; set; }

        [JsonProperty("shortDesc")]
        public string ShortDesc { get; set; }

        [JsonProperty("longDesc")]
        public string LongDesc { get; set; }

        [JsonProperty("iconPath")]
        public string IconPath { get; set; }

        [JsonProperty("endOfGameStatDescs")]
        public List<string> EndOfGameStatDescs { get; set; }
    }
}
