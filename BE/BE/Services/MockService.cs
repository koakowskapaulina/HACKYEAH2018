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
    }
}
