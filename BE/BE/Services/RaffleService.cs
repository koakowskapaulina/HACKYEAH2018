using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Services
{
    public interface IRaffleService
    {
        IEnumerable<int> DoRaffle();
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

        public IEnumerable<int> DoRaffle()
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
            return resultList;
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

                    if (result.Equals("11111"))
                        userGame.RaffleCompatibilityLength = 5;
                    else if(result.Equals("00000"))
                        userGame.RaffleCompatibilityLength = 0;
                    else if(result.Equals("01111") || result.Equals("11110"))
                        userGame.RaffleCompatibilityLength = 4;
                    else if(result.Equals("00111") || result.Equals("01110") || result.Equals("11100") || result.Equals("11101") || result.Equals("10111"))
                        userGame.RaffleCompatibilityLength = 3;
                    else if (result.Equals("00011") || result.Equals("00110") || result.Equals("01100") || result.Equals("11000") || result.Equals("11001") || result.Equals("11010") || result.Equals("10011") || result.Equals("01011") || result.Equals("01101") || result.Equals("10110") || result.Equals("11011"))
                        userGame.RaffleCompatibilityLength = 2;
                    else
                        userGame.RaffleCompatibilityLength = 1;

                    userGamesService.FillRaffleCompatibilityLength(userGame);
                }

            }

        }
    }
}
