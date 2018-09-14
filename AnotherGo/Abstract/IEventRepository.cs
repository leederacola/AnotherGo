using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnotherGo.Models;

namespace AnotherGo.Abstract
{
    public interface IEventRepository
    {
        Task<IEnumerable<GameNight>> GetAllEvents();
        Task<GameNight> GetEventById(int id);
    }
}
