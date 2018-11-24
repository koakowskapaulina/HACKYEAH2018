using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Services
{
    public class MockService
    {
        public IEnumerable<City> InitCities()
        {
            var CitiesList = new List<City>();
            CitiesList.Add(new City(0, "Warsaw", "Poland", "52.237049", "21.017532"));
            CitiesList.Add(new City(1, "Berlin", "Germany", "52.520008", "13.404954"));

            return CitiesList;
        }

        public IEnumerable<User> InitUsers()
        {
            List<User> usersList = new List<User>();
            usersList.Add(new User(0, "iantoniuk@hackyeah.pl", "123", "1;2;3"));
            usersList.Add(new User(1, "apietrowski@hackyeah.pl", "123", "1;2"));
            usersList.Add(new User(2, "pkolakowska@hackyeah.pl", "123", "1;3;2"));
            usersList.Add(new User(3, "mbrzozowska@hackyeah.pl", "123", "1;3;4;2"));
            usersList.Add(new User(4, "knowak@hackyeah.pl", "123", "1;3;5,2,4"));
            usersList.Add(new User(5, "mwalendzik@hackyeah.pl", "123", "1;2;3,4"));

            return usersList;
        }
    }
}
