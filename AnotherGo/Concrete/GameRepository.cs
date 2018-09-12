﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnotherGo.Models;
using AnotherGo.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AnotherGo.Concrete
{
    public class GameRepository : IGameRepository
    {
        private readonly GameNightContext _dbContext;

        public GameRepository(GameNightContext dbContext)
        {
            _dbContext = dbContext;
        }

        // returns games alphabetically
        public async Task<IEnumerable<Game>> GetAllGames()
        {
            //return  await _dbContext.Game.ToListAsync();
            return await _dbContext.Game.OrderBy(g => g.Title).ToListAsync();
        }

        // gets game by id for detail view component
        public async Task<Game> GetGame(int? id)
        {
            var game = await _dbContext.Game
                .FirstOrDefaultAsync(m => m.GameId == id);
            return game;
        }

        public async Task<IEnumerable<Game>> GetPlayerGames(int playerId)
        // INNER JOIN Library ON Library.GameID = Game.GameID
        // WHERE Library.PlayerID = playerId;
        {
            var x = await _dbContext.Library
                .Include(y => y.Game)
                .Where(y => y.PlayerId == playerId)
                .Select(g => g.Game).ToListAsync();
            return x;
        }

        /*** TODO:
         *  this used to redirect to newely created game's detail view. It dont now!!!
         * Add game does not return newely created ID, it needs to!!!!!
         */
        public Game AddGame(Game game)
        {
            _dbContext.Game.Add(game);
            _dbContext.SaveChanges();
            return game;
        }

        public async Task<Game> EditGame(Game game)
        {
            _dbContext.Game.Update(game);
            await _dbContext.SaveChangesAsync();
            return game;

        }

        public async Task<int> DeleteGame(int id)
        {
            var game = await _dbContext.Game.FindAsync(id);
            _dbContext.Game.Remove(game);
            _dbContext.SaveChanges();
            return id;
        }

        public bool GameExist(int id)
        {
            var b = _dbContext.Game.Any(e => e.GameId == id);
            return b;
        }




    }
}
