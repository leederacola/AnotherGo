using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherGo.Models
{
    public class GameNightContext : DbContext
    {
        public GameNightContext()
        {
        }

        public GameNightContext(DbContextOptions<GameNightContext> options)
            : base(options)
        {
        }
        public virtual DbSet<EventGames> EventGames { get; set; }
        public virtual DbSet<EventPlayers> EventPlayers { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameNight> GameNight { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<Player> Player { get; set; }
    }
}
