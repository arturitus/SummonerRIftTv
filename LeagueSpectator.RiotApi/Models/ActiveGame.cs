using Newtonsoft.Json;

namespace LeagueSpectator.RiotApi.Models
{
    public class ActiveGame
    {
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("gameType")]
        public string GameType { get; set; }

        [JsonProperty("gameQueueConfigId")]
        public int GameQueueConfigId { get; set; }

        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        [JsonProperty("observers")]
        public Observers Observers { get; set; }

        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("bannedChampions")]
        public List<BannedChampion> BannedChampions { get; set; }

        [JsonProperty("gameStartTime")]
        public long GameStartTime { get; set; }

        [JsonProperty("gameLength")]
        public int GameLength { get; set; }
    }

}
