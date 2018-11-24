using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Services
{
    public interface IMockService
    {
        IEnumerable<City> InitCities();
        IEnumerable<User> InitUsers();
        City GetCityById(IEnumerable<City> CitiesList, int id);
        IEnumerable<City> GetCities();
    }

    public class MockService : IMockService
    {
        BazkaContext bazka;

        public MockService(BazkaContext _bazkaContext)
        {
            bazka = _bazkaContext;
        }

        public IEnumerable<City> InitCities()
        {
            var CitiesList = new List<City>();
            CitiesList.Add(new City(0, "Warsaw", "Poland", "52.237049", "21.017532"));
            CitiesList.Add(new City(1, "Berlin", "Germany", "52.520008", "13.404954"));
            CitiesList.Add(new City(2, "Paris", "France", "48.864716", "2.349014"));
            CitiesList.Add(new City(3, "Amsterdam", "Netherlands", "52.314224", "4.941841"));
            CitiesList.Add(new City(4, "London", "UK", "51.509865", "-0.118092"));
            CitiesList.Add(new City(5, "Madrid", "Spain", "40.416775", "-3.703790"));
            CitiesList.Add(new City(6, "Rome", "Italy", "41.902782", "12.496366"));
            CitiesList.Add(new City(7, "Lisbon", "Portugal", "38.736946", "-9.142685"));
            CitiesList.Add(new City(8, "New York City", "USA", "40.730610", "-73.935242"));
            CitiesList.Add(new City(9, "Los Angeles", "USA", "34.052235	", "-118.243683"));
            CitiesList.Add(new City(10, "Sydney", "Australia", "-33.865143", "151.209900"));
            CitiesList.Add(new City(11, "Tokyo", "Japan", "35.652832", "139.839478"));
            CitiesList.Add(new City(12, "Seoul", "South Korea", "37.532600", "127.024612"));
            CitiesList.Add(new City(13, "Moscow", "Russia", "55.751244", "37.618423"));
            CitiesList.Add(new City(14, "Santiago", "Chile", "-33.459229", "-70.645348"));
            CitiesList.Add(new City(15, "Buenos Aires", "Argentina", "-34.603722", "-58.381592"));
            CitiesList.Add(new City(16, "Dubai", "United Arab Emirates", "25.276987", "55.296249"));
            CitiesList.Add(new City(17, "Athens", "Greece", "37.983810", "23.727539"));
            CitiesList.Add(new City(18, "Singapore", "Singapore", "1.290270", "103.851959"));
            CitiesList.Add(new City(19, "Panama City", "Panama", "8.983333", "-79.516670"));
            CitiesList.Add(new City(20, "Cape Town", "South Africa", "-33.844166", "18.698610"));

            //CitiesList.Add(new City(, "", "", "", ""));

            return CitiesList;
        }

        public City GetCityById(IEnumerable<City> CitiesList, int id)
        {             
            var city = CitiesList.Where(x => x.CityID.Equals(id)).FirstOrDefault();

            return city;
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

        public IEnumerable<City> GetCities()
        {
            //BazkaContext bazka = new BazkaContext();
            return bazka.Cities.ToList();
        }
    }
}
