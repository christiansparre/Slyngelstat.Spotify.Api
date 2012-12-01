using Newtonsoft.Json;

namespace Slyngelstat.Spotify.LocalApi
{
    public class Track
    {
        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("track_type")]
        public string TrackType { get; set; }

        [JsonProperty("track_resource")]
        public Resource TrackResource { get; set; }

        [JsonProperty("artist_resource")]
        public Resource ArtistResource { get; set; }

        [JsonProperty("album_resource")]
        public Resource AlbumResource { get; set; }
    }
}