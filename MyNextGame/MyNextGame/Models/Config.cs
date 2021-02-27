using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextGame.Models
{
    public class Config
    {
        [JsonProperty("client_id")]
        public String clientId { get; set; }

        [JsonProperty("client_secret")]
        public String clientSecret { get; set; }

        public String url { get; set; }

        [JsonProperty("token_url")]
        public String tokenUrl { get; set; }
    }
}
