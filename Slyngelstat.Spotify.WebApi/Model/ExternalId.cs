using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class ExternalId
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}