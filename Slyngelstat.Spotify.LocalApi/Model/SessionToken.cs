using Newtonsoft.Json;

namespace Slyngelstat.Spotify.LocalApi
{
    public class SessionToken
    {
        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}