using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnotherGo.Abstract;
using AnotherGo.Models;
using Microsoft.EntityFrameworkCore;

namespace AnotherGo.Concrete
{
    public class Eventrepository : IEventRepository
    {
        private readonly GameNightContext _dbContext;

        public Eventrepository( GameNightContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GameNight>> GetAllEvents()
        {
            var data = await _dbContext.GameNight.OrderBy(e => e.EventDate).ToListAsync();
            return data;
        }

        public async Task<GameNight> GetEventById(int id)
        {
            var data = await _dbContext.GameNight.FirstOrDefaultAsync(d => d.GameNightId == id);
            return data;
        }
    }
}
