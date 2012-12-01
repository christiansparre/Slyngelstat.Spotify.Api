using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slyngelstat.Spotify.WebApi
{
    public class SpotifyUri
    {
        private string uri;

        public SpotifyUri(string uri)
        {
            this.uri = uri;
        }

        public string Type { get { return uri.Split(':')[1]; } }
        public string Id { get { return uri.Split(':')[2]; } }
        public string Uri { get { return uri; } }

        public static implicit operator SpotifyUri(string uri)
        {
            var u = new SpotifyUri(uri);
            return u;
        }

        public static implicit operator string(SpotifyUri uri)
        {
            return uri.Uri;
        }

        public override string ToString()
        {
            return uri;
        }
    }
}
