using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherGo.Models
{
    public class GameNight
    {
        public int GameNightId { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventDate { get; set; }
        public string Notes { get; set; }

        public ICollection<EventGames> EventGames { get; set; }
        public ICollection<EventPlayers> EventPlayers { get; set; }
    }
}
