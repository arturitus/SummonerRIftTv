using System.Text.Json.Serialization;

namespace LeagueSpectator.MVVM.Models
{
    public class Rune
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("majorChangePatchVersion")]
        public string MajorChangePatchVersion { get; set; }

        [JsonPropertyName("tooltip")]
        public string Tooltip { get; set; }

        [JsonPropertyName("shortDesc")]
        public string ShortDesc { get; set; }

        [JsonPropertyName("longDesc")]
        public string LongDesc { get; set; }

        [JsonPropertyName("iconPath")]
        public string IconPath { get; set; }

        [JsonPropertyName("endOfGameStatDescs")]
        public List<string> EndOfGameStatDescs { get; set; }
    }
}
