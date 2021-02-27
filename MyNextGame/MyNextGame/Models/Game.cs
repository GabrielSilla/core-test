using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextGame.Models
{
    public class Game
    {
        public IEnumerable<int>  artworks { get; set; }
        public String cover { get; set; }

        [JsonProperty("first_release_date")]
        public String releaseDate { get; set; }
        public IEnumerable<int> genres { get; set; }
        public String name { get; set; }
        public double rating { get; set; }
        public IEnumerable<int> screenshots { get; set; }

        [JsonProperty("similar_games")]
        public IEnumerable<int> similarGames { get; set; }
        public String storyline { get; set; }
        public String summary { get; set; }

        [JsonProperty("total_rating")]
        public double totalRating { get; set; }
        
        [JsonProperty("version_title")]
        public String versionTitle { get; set; }

        [JsonProperty("involved_companies")]
        public IEnumerable<int> involvedCompanies { get; set; }
    }
}
