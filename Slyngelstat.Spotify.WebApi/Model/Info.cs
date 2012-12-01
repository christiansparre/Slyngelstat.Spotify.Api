using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class Info
    {
        [JsonProperty("num_results")]
        public int NumberOfResults { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        public bool HasMoreResults { get { return NumberOfResults > Limit; } }

    }
}