using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var mockService = new MockService();
            var cities = mockService.InitCities();

            var city = cities.Where(x => x.CityID.Equals(id));

            return city.ToString();
        }
    }
}