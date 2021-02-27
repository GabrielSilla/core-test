using MyNextGame.Models;
using MyNextGame.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Net.Http.Headers;

namespace MyNextGame.Services
{
    public class GameService
    {
        public HttpClient client { get; set; }
        public TokenUtils tokenUtils { get; set; }
        public Config config { get; set; }

        public GameService(Config config)
        {
            this.config = config;
            this.client = HttpClientFactory.Create();
            this.tokenUtils = new TokenUtils(config);

            client.DefaultRequestHeaders.Add("Client-ID", config.clientId);
        }

        public async Task<IEnumerable<Game>> getGameList()
        {
            var token = await tokenUtils.getToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var stringContent = new StringContent("fields artworks,category,cover,first_release_date,genres,involved_companies,name,platforms,rating,screenshots,similar_games,storyline,summary,total_rating;", UnicodeEncoding.UTF8, MediaTypeNames.Text.Plain);

            HttpResponseMessage response = await this.client.PostAsync($"{config.url}/games", stringContent);
            IEnumerable<Game> gameList = await response.Content.ReadAsAsync<IEnumerable<Game>>();

            return gameList;
        }

        public ItemTese getItem()
        {
            var test = new ItemTese();
            test.name = "BABLA";
            test.origin = "23123";
            test.uuid = "123ha";
            test.destination = "123123123";

            return test;
        }
    }
}
