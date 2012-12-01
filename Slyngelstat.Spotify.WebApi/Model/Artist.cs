using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class Artist
    {
        [JsonProperty("href")]
        public SpotifyUri Href { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public IEnumerable<Album> Albums { get; set; }
    }
}