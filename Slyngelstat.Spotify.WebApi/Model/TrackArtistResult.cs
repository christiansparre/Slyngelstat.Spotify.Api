using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class TrackArtistResult
    {

        [JsonProperty("href")]
        public SpotifyUri Href { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}