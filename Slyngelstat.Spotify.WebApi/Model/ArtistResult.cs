using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class ArtistResult
    {
        [JsonProperty("href")]
        public SpotifyUri Href { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public string Popularity { get; set; }

        public override string ToString()
        {
            return string.Format("Name = {0}", this.Name);
        }
    }
}