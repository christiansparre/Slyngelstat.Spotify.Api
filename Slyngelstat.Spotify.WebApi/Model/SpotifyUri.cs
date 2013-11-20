#region license
// Copyright (c) 2013 Christian Sparre
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion
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
