using System;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Slyngelstat.Spotify.WebApi
{
    public class WebApiClient
    {
        private readonly HttpClient httpClient;

        public WebApiClient()
        {
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Search for an album
        /// </summary>
        public AlbumSearchResult SearchAlbums(string term, int page = 1)
        {
            string resp = GetWebApiResponse(BuildSearchUri(BaseUrls.SearchAlbum, term, page));

            return JsonConvert.DeserializeObject<AlbumSearchResult>(resp);
        }

        /// <summary>
        /// Search for an artist
        /// </summary>
        public ArtistSearchResult SearchArtists(string term, int page = 1)
        {
            string resp = GetWebApiResponse(BuildSearchUri(BaseUrls.SearchArtist, term, page));

            return JsonConvert.DeserializeObject<ArtistSearchResult>(resp);
        }

        /// <summary>
        /// Search for a track
        /// </summary>
        public TrackSearchResult SearchTracks(string term, int page = 1)
        {
            string resp = GetWebApiResponse(BuildSearchUri(BaseUrls.SearchTrack, term, page));

            return JsonConvert.DeserializeObject<TrackSearchResult>(resp);
        }

        /// <summary>
        /// Looks up an artist
        /// </summary>
        public Artist LookupArtist(string uri)
        {
            return LookupArtist((SpotifyUri)uri);
        }

        /// <summary>
        /// Looks up an artist
        /// </summary>
        public Artist LookupArtist(SpotifyUri uri)
        {
            var jartist = GetJObject(uri, "albumdetail")["artist"];
            var artist = jartist.ToObject<Artist>();

            artist.Albums = jartist["albums"].Select(s => s["album"].ToObject<Album>()).ToList();

            return artist;
        }

        private JObject GetJObject(SpotifyUri uri, string extras = null)
        {
            string resp = GetWebApiResponse(BuildLookupUri(BaseUrls.Lookup, uri, extras));

            return JObject.Parse(resp);
        }


        /// <summary>
        /// Looks up an album
        /// </summary>
        public Album LookupAlbum(string uri)
        {
            return LookupAlbum((SpotifyUri)uri);
        }

        /// <summary>
        /// Looks up an album
        /// </summary>
        public Album LookupAlbum(SpotifyUri uri)
        {
            return GetJObject(uri, "trackdetail")["album"].ToObject<Album>();
        }


        /// <summary>
        /// Looks up a track
        /// </summary>
        public Track LookupTrack(string uri)
        {
            return LookupTrack((SpotifyUri)uri);
        }

        /// <summary>
        /// Looks up a track
        /// </summary>
        public Track LookupTrack(SpotifyUri uri)
        {
            return GetJObject(uri)["track"].ToObject<Track>();
        }


        private string GetWebApiResponse(Uri requestUri)
        {
            var searchTask = httpClient.GetStringAsync(requestUri);
            searchTask.Wait();
            return searchTask.Result;
        }

        private Uri BuildLookupUri(string baseUrl, SpotifyUri uri, string extras = null)
        {
            string url = string.Format("{0}?uri={1}", baseUrl, uri);

            if (extras != null)
            {
                url = url + "&extras=" + extras;
            }

            return new Uri(url);
        }

        /// <summary>
        /// Builds a search uri
        /// </summary>
        public Uri BuildSearchUri(string baseUrl, string term, int page)
        {
            string url = string.Format("{0}?q={1}", baseUrl, HttpUtility.UrlEncode(term));

            if (page > 1)
            {
                url = url + "&page=" + page;
            }

            return new Uri(url);
        }

        public JObject GetRawResult(Uri uri)
        {
            var resp = GetWebApiResponse(uri);

            return JObject.Parse(resp);
        }
    }
}