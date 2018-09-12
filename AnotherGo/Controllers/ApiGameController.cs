using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnotherGo.Abstract;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnotherGo.Controllers
{
    [Produces("application/json")]
    [EnableCors("LocalTest")]
    [Route("api/Games")]
    public class GamesApiController : ControllerBase
    {
        private readonly IGameRepository _gamesRepository;

        public GamesApiController(IGameRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        // GET: api/games
        [Route("")]
        [HttpGet]
        public Task<IEnumerable<Models.Game>> GetAllGames()
        {
            var games = _gamesRepository.GetAllGames();
            return games;
        }

        // GET: api/games/id
        [Route("{id:int}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = await _gamesRepository.GetGame(id);

            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        // Get: api/games/player/playerId
        [Route("player/{playerId}")]
        [HttpGet("{playerId}")]
        public async Task<IActionResult> GetPlayerGames([FromRoute] int playerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var playerGames = await _gamesRepository.GetPlayerGames(playerId);

            if (playerGames == null)
            {
                return NotFound();
            }
            return Ok(playerGames);

        }
    }
}