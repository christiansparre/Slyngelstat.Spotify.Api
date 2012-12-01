using Newtonsoft.Json;

namespace Slyngelstat.Spotify.LocalApi
{
    public class Location
    {
        [JsonProperty("og")]
        public string Og { get; set; }
    }
}