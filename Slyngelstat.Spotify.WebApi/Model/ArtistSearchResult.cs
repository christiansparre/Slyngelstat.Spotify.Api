using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class ArtistSearchResult : SearchResult
    {
        [JsonProperty("artists")]
        public IEnumerable<ArtistResult> Artists { get; set; }
    }
}