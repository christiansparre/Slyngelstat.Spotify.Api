using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slyngelstat.Spotify.WebApi
{
    public class BaseUrls
    {
        public static readonly string SearchAlbum = "http://ws.spotify.com/search/1/album.json";
        public static readonly string SearchArtist = "http://ws.spotify.com/search/1/artist.json";
        public static readonly string SearchTrack = "http://ws.spotify.com/search/1/track.json";
        public static readonly string Lookup = "http://ws.spotify.com/lookup/1/.json";
    }
}
