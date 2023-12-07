using System.Text.Json.Serialization;

namespace LeagueSpectator.MVVM.Models
{
    public class SummonerSpell
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonPropertyName("cooldown")]
        public int Cooldown { get; set; }

        [JsonPropertyName("gameModes")]
        public List<string> GameModes { get; set; }

        [JsonPropertyName("iconPath")]
        public string IconPath { get; set; }
    }
}
