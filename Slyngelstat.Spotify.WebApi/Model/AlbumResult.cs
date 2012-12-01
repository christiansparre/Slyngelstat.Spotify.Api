using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class AlbumResult
    {
        [JsonProperty("artists")]
        public IEnumerable<AlbumArtistResult> Artists { get; set; }

        [JsonProperty("href")]
        public SpotifyUri Href { get; set; }

        [JsonProperty("availability")]
        public Availability Availability { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public string Popularity { get; set; }

        [JsonProperty("external-ids")]
        public IEnumerable<ExternalId> ExternalIds { get; set; }

        public override string ToString()
        {
            return string.Format("Name = {0}", this.Name);
        }
    }
}