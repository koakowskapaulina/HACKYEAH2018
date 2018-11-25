using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Services
{
    public class UserGamesService
    {
        BazkaContext bazka;

        public UserGamesService(BazkaContext _bazkaContext)
        {
            bazka = _bazkaContext;
        }

        public IEnumerable<UserGames> GetUserGames(long id)
        {            
            return bazka.UserGames.Where(x=>x.UserID.Equals(id)).ToList();
        }

        public void CreateUserGame(int userId, int[] citiesIds)
        {
            var userGame = new UserGames
            {

            }
            bazka.UserGames.Add(userGame);
        }
    }
}
