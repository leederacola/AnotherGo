using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnotherGo.Models;

namespace AnotherGo.Abstract
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllPlayers();
        Task<Player> GetPlayerById(int id);
        // includes players games
        // Task<Player> GetPlayerGamesById(int id);
        Task<Player> CreatePlayer(Player player);
        Task<Player> EditPlayer(Player player);
        Task<int> DeletePlayer(int id);
        bool PlayerExist(int id);

        //Task<IEnumerable<Game>> GetPlayerGames(int id);
    }
}