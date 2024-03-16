using System.Text.Json.Serialization;

namespace SummonerRiftTv.RiotApi.Models
{
    public class Observers
    {
        [JsonPropertyName("encryptionKey")]
        public string EncryptionKey { get; set; }
    }
}
