using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class AlbumSearchResult : SearchResult
    {
        [JsonProperty("albums")]
        public IEnumerable<AlbumResult> Albums { get; set; }
    }
}