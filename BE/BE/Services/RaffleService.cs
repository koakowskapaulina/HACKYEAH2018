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
        UserGamesService userGamesService;

        public RaffleService(IUserService _userService, UserGamesService _userGamesService)
        {
            userService = _userService;
            userGamesService = _userGamesService;
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
                var userGames = userGamesService.GetUserGames(user.UserID);

                foreach (var userGame in userGames)
                {
                    var userGameRoute = userGame.SelectedRoute.Split(';');
                    
                    int[] compatibilityMatrix = new int[5] { 0, 0, 0, 0, 0 };
                    for (int i = 0; i < 5; i++)
                    {
                        if (userGameRoute[i].Equals(RaffleResultList[i].ToString()))
                        {
                            compatibilityMatrix[i] = 1;
                        }
                    }
                    string result = string.Join("", compatibilityMatrix);
                }

            }

        }
    }
}
