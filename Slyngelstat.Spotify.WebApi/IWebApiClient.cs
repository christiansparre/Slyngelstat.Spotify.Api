using System;
using Newtonsoft.Json.Linq;

namespace Slyngelstat.Spotify.WebApi
{
    public interface IWebApiClient
    {
        /// <summary>
        /// Search for an album
        /// </summary>
        AlbumSearchResult SearchAlbums(string term, int page = 1);

        /// <summary>
        /// Search for an artist
        /// </summary>
        ArtistSearchResult SearchArtists(string term, int page = 1);

        /// <summary>
        /// Search for a track
        /// </summary>
        TrackSearchResult SearchTracks(string term, int page = 1);

        /// <summary>
        /// Looks up an artist
        /// </summary>
        Artist LookupArtist(string uri);

        /// <summary>
        /// Looks up an artist
        /// </summary>
        Artist LookupArtist(SpotifyUri uri);

        /// <summary>
        /// Looks up an album
        /// </summary>
        Album LookupAlbum(string uri);

        /// <summary>
        /// Looks up an album
        /// </summary>
        Album LookupAlbum(SpotifyUri uri);

        /// <summary>
        /// Looks up a track
        /// </summary>
        Track LookupTrack(string uri);

        /// <summary>
        /// Looks up a track
        /// </summary>
        Track LookupTrack(SpotifyUri uri);

        /// <summary>
        /// Builds a search uri
        /// </summary>
        Uri BuildSearchUri(string baseUrl, string term, int page);

        JObject GetRawResult(Uri uri);
    }
}