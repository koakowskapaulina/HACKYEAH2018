using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Services
{
    public interface IRaffleService
    {
        void DoRaffle();
        void CompareResults(List<int> RaffleResultList);
    }

    public class RaffleService : IRaffleService
    {
        IUserService userService;

        public RaffleService(IUserService _userService)
        {
            userService = _userService;
        }

        public void DoRaffle()
        {
            var resultList = new List<int>();

            int id = 0;
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                id = rnd.Next(1, 20);
                while (resultList.Contains(id))
                {
                    id = rnd.Next(1, 20);
                }
                resultList.Add(id);
            }

            CompareResults(resultList);
            //return resultList;
        }

        public void CompareResults(List<int> RaffleResultList)
        {
            var usersLists = userService.GetUsers();
            foreach(var user in usersLists)
            {
                //var userGames = ...GetUserGames(user.UserID).toList();
                //var userGames = new List<UserGames>();
                //userGames.Add()

                //foreach (var userGame in userGames)
                //{
                //    var userGameRoute = userGame.Route.Split(';');

                //}

            }

        }
    }
}
