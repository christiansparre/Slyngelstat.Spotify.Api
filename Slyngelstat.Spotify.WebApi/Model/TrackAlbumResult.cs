using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class TrackAlbumResult
    {

        [JsonProperty("released")]
        public string Released { get; set; }

        [JsonProperty("Href")]
        public SpotifyUri Href { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("availability")]
        public Availability Availability { get; set; }
    }
}