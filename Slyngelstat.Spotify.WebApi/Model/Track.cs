using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class Track
    {

        [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("track-number")]
        public string TrackNumber { get; set; }

        [JsonProperty("disc-number")]
        public string DiscNumber { get; set; }

        [JsonProperty("popularity")]
        public string Popularity { get; set; }

        [JsonProperty("external-ids")]
        public IEnumerable<ExternalId> ExternalIds { get; set; }

        [JsonProperty("length")]
        public string Length { get; set; }

        [JsonProperty("href")]
        public SpotifyUri Href { get; set; }

        [JsonProperty("artists")]
        public IEnumerable<Artist> Artists { get; set; }

        [JsonProperty("availability")]
        public Availability Availability { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}