using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slyngelstat.Spotify.WebApi;

namespace Slyngelstat.Spotity.WebApi.Test
{
    [TestClass]
    public class OnlineTests
    {
        private WebApiClient webApiClient;



        [TestInitialize]
        public void Init()
        {
            webApiClient = new WebApiClient();
        }


        [TestMethod]
        public void TestSearchAlbum()
        {
            // Arrange
            string searchTerm = "Guitar Gangsters";


            // Act
            var searchResult = webApiClient.SearchAlbums(searchTerm);

            // Assert

            Assert.IsTrue(searchResult.Albums.Any());
            Assert.IsNotNull(searchResult.Albums.FirstOrDefault(f => f.Href.Uri == SpotifyUris.Volbeat_GuitarGansters));
        }

        [TestMethod]
        public void TestSearchArtist()
        {
            // Arrange
            string searchTerm = "Bruno Mars";

            // Act
            var searchResult = webApiClient.SearchArtists(searchTerm);

            // Assert
            Assert.IsTrue(searchResult.Artists.Any());
            Assert.IsNotNull(searchResult.Artists.FirstOrDefault(f => f.Href.Uri == SpotifyUris.BrunoMars));
        }

        [TestMethod]
        public void TestSearchTrack()
        {
            string searchTerm = "Pinball Wizard";
            var searchResult = webApiClient.SearchTracks(searchTerm);
            var timer = Stopwatch.StartNew();
            // Arrange

            var res2= webApiClient.SearchTracks("Diamonds");
            // Act
            timer.Stop();

            // Assert
            Assert.IsTrue(searchResult.Tracks.Any());
            Assert.IsNotNull(searchResult.Tracks.FirstOrDefault(f => f.Href.Uri == SpotifyUris.TheWho_PinballWizard));
        }

        [TestMethod]
        public void TestLookupArtist()
        {
            // Arrange

            // Act
            var artist = webApiClient.LookupArtist(SpotifyUris.CreedenceClearwaterRevival);

            // Assert
            Assert.IsNotNull(artist);
        }

        [TestMethod]
        public void TestLookupAlbum()
        {
            // Arrange

            // Act
            var album = webApiClient.LookupAlbum(SpotifyUris.TheBlueVan_LoveShot);

            // Assert
            Assert.IsNotNull(album);
        }

        [TestMethod]
        public void TestLookupTrack()
        {
            // Arrange
           
            // Act
            var track = webApiClient.LookupTrack(SpotifyUris.MumfordAndSons_IWillWait);

            // Assert
            Assert.IsNotNull(track);
        }

        public class SpotifyUris
        {
            public static readonly string Volbeat_GuitarGansters =
                "spotify:album:0IzDJ3kTqKbk9fDIOQmn76";

            public static readonly string BrunoMars = "spotify:artist:0du5cEVh5yTK9QJze8zA0C";

            public static readonly string TheWho_PinballWizard = "spotify:track:5jaBGevFXiV9s1kAYyf8JR";

            public static readonly string CreedenceClearwaterRevival = "spotify:artist:3IYUhFvPQItj6xySrBmZkd";

            public static readonly string TheBlueVan_LoveShot = "spotify:album:07SAKrtnapwvzHD4S1NLCL";

            public static readonly string MumfordAndSons_IWillWait = "spotify:track:71O1jD7bF3cdMPvPi186V6";
        }
    }
}
