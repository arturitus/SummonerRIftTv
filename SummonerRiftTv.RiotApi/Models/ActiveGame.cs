using System.Text.Json.Serialization;

namespace SummonerRiftTv.RiotApi.Models
{
    public class ActiveGame
    {
        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        [JsonPropertyName("mapId")]
        public int MapId { get; set; }

        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        [JsonPropertyName("gameType")]
        public string GameType { get; set; }

        [JsonPropertyName("gameQueueConfigId")]
        public int GameQueueConfigId { get; set; }

        [JsonPropertyName("participants")]
        public List<Participant> Participants { get; set; }

        [JsonPropertyName("observers")]
        public Observers Observers { get; set; }

        [JsonPropertyName("platformId")]
        public string PlatformId { get; set; }

        [JsonPropertyName("bannedChampions")]
        public List<BannedChampion> BannedChampions { get; set; }

        [JsonPropertyName("gameStartTime")]
        public long GameStartTime { get; set; }

        [JsonPropertyName("gameLength")]
        public int GameLength { get; set; }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ActiveGame))]
    [JsonSerializable(typeof(Summoner))]
    [JsonSerializable(typeof(Account))]
    [JsonSerializable(typeof(HashSet<LeagueItem>))]
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }

}
