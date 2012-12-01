using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class TrackResult
    {

        [JsonProperty("album")]
        public TrackAlbumResult Album { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public string Popularity { get; set; }

        [JsonProperty("external-ids")]
        public IEnumerable<ExternalId> ExternalIds { get; set; }

        [JsonProperty("length")]
        public double Lenght { get; set; }

        [JsonProperty("artists")]
        public IEnumerable<TrackArtistResult> Artists { get; set; }
        [JsonProperty("href")]
        public SpotifyUri Href { get; set; }

        [JsonProperty("track-number")]
        public string TrackNumber { get; set; }
    }
}