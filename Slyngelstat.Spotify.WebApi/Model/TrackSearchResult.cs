using System.Collections.Generic;
using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class TrackSearchResult : SearchResult
    {

        [JsonProperty("tracks")]
        public IEnumerable<TrackResult> Tracks { get; set; }
    }
}