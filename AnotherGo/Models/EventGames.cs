using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherGo.Models
{
    public class EventGames
    {
        public int EventPlayersId { get; set; }
        public int GameNightId { get; set; }
        public int GameId { get; set; }

        public GameNight GameNight { get; set; }
        public Game Game { get; set; }
    }
}
