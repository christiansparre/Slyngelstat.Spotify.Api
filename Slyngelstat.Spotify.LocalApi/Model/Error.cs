using Newtonsoft.Json;

namespace Slyngelstat.Spotify.LocalApi
{
    public class Error
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}