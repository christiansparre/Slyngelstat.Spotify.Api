using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Slyngelstat.Spotify.LocalApi
{
    /// <summary>
    /// The local Spotify API client. Can perform simple tasks against the SpotifyWebHelper process. Such as playing tracks etc. pausing, returning status etc.
    /// </summary>
    public class LocalApiClient
    {
        private HttpClient httpClient;

        public string OAuthToken { get; private set; }
        public SessionToken SessionToken { get; private set; }

        /// <summary>
        /// Creates and initializes a LocalApiClient object
        /// </summary>
        public LocalApiClient()
        {
            httpClient = new HttpClient();

            // Set Origin and Referer to get around spotify's attempts to protect the service
            httpClient.DefaultRequestHeaders.Add("Origin", "https://embed.spotify.com");
            httpClient.DefaultRequestHeaders.Add("Referer", "https://embed.spotify.com/?uri=spotify:track:1R2SZUOGJqqBiLuvwKOT2Y");
            
            SetOAuthToken();
            SetSessionToken();
        }

        /// <summary>
        /// Pauses the current playback
        /// </summary>
        /// <returns></returns>
        public Status Pause()
        {
            string path = "remote/pause.json?pause=true";

            var resp = GetLocalApiResponse(path, true, true, -1);

            return JsonConvert.DeserializeObject<Status>(resp);
        }

        /// <summary>
        /// Plays a spotify uri, this could be an artist, album, track, playlist etc. that have a valid id
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public Status Play(string uri)
        {
            string path = "remote/play.json?uri=" + uri;

            var resp = GetLocalApiResponse(path, true, true, -1);

            return JsonConvert.DeserializeObject<Status>(resp);
        }

        /// <summary>
        /// Resumes the current playback
        /// </summary>
        public Status Resume()
        {
            string path = "remote/pause.json?pause=false";

            var resp = GetLocalApiResponse(path, true, true, -1);

            return JsonConvert.DeserializeObject<Status>(resp);
        }

        /// <summary>
        /// Returns the current status
        /// </summary>
        public Status CurrentStatus
        {
            get { return GetCurrentStatus(); }
        }

        private Status GetCurrentStatus()
        {
            string path = "remote/status.json";

            var resp = GetLocalApiResponse(path, true, true, -1);

            return JsonConvert.DeserializeObject<Status>(resp);
        }

        private void SetSessionToken()
        {
            string path = "simplecsrf/token.json";

            var resp = GetLocalApiResponse(path, false, false, -1);

            SessionToken = JsonConvert.DeserializeObject<SessionToken>(resp);
        }

        private void SetOAuthToken()
        {
            string tokenResponse = DownloadString("https://embed.spotify.com/openplay/?uri=spotify:track:1R2SZUOGJqqBiLuvwKOT2Y");
            string tokenLine = tokenResponse.Replace(" ", "").Split(new string[] { "\n" }, StringSplitOptions.None).FirstOrDefault(f => f.StartsWith("tokenData"));

            if (tokenLine == null)
            {
                throw new Exception("Could not find tokenData ");
            }

            OAuthToken = tokenLine.Split(new string[] { "'" }, StringSplitOptions.None)[1];
        }

        private string DownloadString(string uri)
        {
            var task = httpClient.GetStringAsync(uri);
            task.Wait();
            return task.Result;
        }

        private string GetLocalApiResponse(string request, bool oauth, bool sessionToken, int wait)
        {
            string parameters = "?&ref=&cors=";
            if (request.Contains("?"))
            {
                parameters = parameters.Substring(1);
            }

            if (oauth)
            {
                parameters += "&oauth=" + OAuthToken;
            }
            if (sessionToken)
            {
                parameters += "&csrf=" + SessionToken.Token;
            }

            if (wait != -1)
            {
                parameters += "&returnafter=" + wait;
                parameters += "&returnon=login%2Clogout%2Cplay%2Cpause%2Cerror%2Cap";
            }

            string a = "http://" + "localhost" + ":4380/" + request + parameters;

            try
            {
                return DownloadString(a);
            }
            catch (Exception ex)
            {
                var webHelperProcess = Process.GetProcesses().FirstOrDefault(f => f.ProcessName == "SpotifyWebHelper");

                if (webHelperProcess == null)
                {
                    try
                    {
                        // The SpotifyWebHelper is not running attempt to start it
                        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Spotify\\Data\\SpotifyWebHelper.exe");
                    }
                    catch (Exception iEx)
                    {
                        throw new Exception("Failed to launch SpotifyWebHelper", iEx);
                    }
                }

                // The Web helper should be running, try again
                try
                {
                    return DownloadString(a);
                }
                catch (Exception iEx)
                {
                    throw new Exception("SpotifyWebHelper appears to be running, but an unknown error occurred", iEx);
                }
            }
        }
    }
}
