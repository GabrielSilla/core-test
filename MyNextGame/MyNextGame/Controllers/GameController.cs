using Microsoft.AspNetCore.Mvc;
using MyNextGame.Models;
using MyNextGame.Services;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MyNextGame.Controllers
{
    [ApiController]
    [Route("v1/games")]
    public class GameController : ControllerBase
    {
        public GameService gameService;

        public GameController(GameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        [Route("list")]
        [Produces("application/json")]
        public async Task<IEnumerable<Game>> listGames()
        {
            IEnumerable<Game> response = await this.gameService.getGameList();
            return response;
        }

        [HttpGet]
        [Route("test")]
        [Produces("application/json")]
        public ItemTese getTest()
        {
            return gameService.getItem();
        }
    }
}
