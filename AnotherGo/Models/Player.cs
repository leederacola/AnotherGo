using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherGo.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
