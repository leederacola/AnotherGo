using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnotherGo.Abstract;
using AnotherGo.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnotherGo.Controllers
{
    [Produces("application/json")]
    [EnableCors("LocalTest")]
    [Route("api/players")]
    public class ApiPlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public ApiPlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        //GET: api/players
        [Route("")]
        [HttpGet]
        public Task<IEnumerable<Player>> GetAllPlayers()
        {
            var players = _playerRepository.GetAllPlayers();
            return players;
        }
    }
}
