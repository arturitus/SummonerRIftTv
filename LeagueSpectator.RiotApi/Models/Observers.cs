using Newtonsoft.Json;

namespace LeagueSpectator.RiotApi.Models
{
    public class Observers
    {
        [JsonProperty("encryptionKey")]
        public string EncryptionKey { get; set; }
    }
}
