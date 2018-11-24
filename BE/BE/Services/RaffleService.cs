using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Services
{
    public interface IRaffleService
    {
        IEnumerable<int> DoRaffle();
    }

    public class RaffleService : IRaffleService
    {
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

            return resultList;
        }

    }
}
