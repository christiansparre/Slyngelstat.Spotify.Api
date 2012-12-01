using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Slyngelstat.Spotify.WebApi
{
    public class Availability
    {

        [JsonProperty("territories")]
        public string TerritoriesData { get; set; }

        public IEnumerable<string> Territories { get { return TerritoriesData.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).AsEnumerable(); } }
    }
}