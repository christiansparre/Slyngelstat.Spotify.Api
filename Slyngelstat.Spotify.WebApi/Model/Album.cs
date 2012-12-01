using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class Album
    {
        [JsonProperty("artist-id")]
        public SpotifyUri ArtistId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("released")]
        public string Released { get; set; }

        [JsonProperty("href")]
        public SpotifyUri Href { get; set; }

        [JsonProperty("availability")]
        public Availability Availability { get; set; }

        [JsonProperty("tracks")]
        public IEnumerable<Track> Tracks { get; set; }
    }
}