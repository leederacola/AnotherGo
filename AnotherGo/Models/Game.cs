using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherGo.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string GameDescription { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public string ImgPath { get; set; }
        public string ThumbPath { get; set; }
    }
}
