using Newtonsoft.Json;

namespace LeagueSpectator.MVVM.Models
{
    public class SummonerSpell
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }

        [JsonProperty("cooldown")]
        public int Cooldown { get; set; }

        [JsonProperty("gameModes")]
        public List<string> GameModes { get; set; }

        [JsonProperty("iconPath")]
        public string IconPath { get; set; }
    }
}
