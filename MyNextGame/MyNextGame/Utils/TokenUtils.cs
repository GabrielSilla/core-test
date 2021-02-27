using MyNextGame.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyNextGame.Utils
{
    public class TokenUtils
    {
        public HttpClient httpClient;
        public Config config;

        public TokenUtils(Config config)
        {
            httpClient = HttpClientFactory.Create();
            this.config = config;
        }

        public async Task<String> getToken()
        {
            String path = $"{config.tokenUrl}?client_id={config.clientId}&client_secret={config.clientSecret}&grant_type=client_credentials";
            var response = await httpClient.PostAsync(path, null);

            var content = await response.Content.ReadAsStringAsync();
            
            JObject jsonData = JObject.Parse(content);
            return jsonData.GetValue("access_token").ToString();
        }
    }
}
