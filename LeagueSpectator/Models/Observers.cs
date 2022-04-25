using Newtonsoft.Json;

namespace LeagueSpectator.Models
{
    public class Observers
    {
        [JsonProperty("encryptionKey")]
        public string? EncryptionKey { get; set; }
    }

}
