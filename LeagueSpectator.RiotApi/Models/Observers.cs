using System.Text.Json.Serialization;

namespace LeagueSpectator.RiotApi.Models
{
    public class Observers
    {
        [JsonPropertyName("encryptionKey")]
        public string EncryptionKey { get; set; }
    }
}
