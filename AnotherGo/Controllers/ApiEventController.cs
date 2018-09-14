using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnotherGo.Abstract;

namespace AnotherGo.Controllers
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Cors.EnableCors("LocalTest")]
    [Route("api/events")]
    public class ApiEventController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public ApiEventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET: api/events
        [Route("")]
        [HttpGet]
        public Task<IEnumerable<Models.GameNight>> GetAllGames()
        {
            var data = _eventRepository.GetAllEvents();
            return data;
        }

        // GET: api/events/id
        [Route("{id:int}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _eventRepository.GetEventById(id);

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}