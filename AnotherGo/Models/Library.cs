using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherGo.Models
{
    public class Library
    {
        public int LibraryId { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }

        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}
