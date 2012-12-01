using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class SearchResult
    {
        [JsonProperty("info")]
        public Info Info { get; set; }
    }
}