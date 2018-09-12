using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherGo.Models
{
    public class EventPlayers
    {
        public int EventPlayersId { get; set; }
        public int GameNightId { get; set; }
        public int PlayerId { get; set; }

        public GameNight GameNight { get; set; }
        public Player Player { get; set; }
    }
}
