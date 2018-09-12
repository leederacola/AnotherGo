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

        public DbSet<Game> Game { get; set; }
        public DbSet<Library> Library { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<GameNight> GameNight { get; set; }
        public DbSet<EventGames> EventGames { get; set; }
        public DbSet<EventPlayers> EventPlayers { get; set; }


    }
}
