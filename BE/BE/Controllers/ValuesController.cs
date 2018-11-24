using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("chcem/api")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var mockService = new MockService();
            var cities = mockService.InitCities();

            var city = cities.First();
            string cityString = city.CityID + "." + city.CityName;

            //return new string[] { "bier", "api", "rób","mati uj" };
            return new string[] { cityString };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var mockService = new MockService();
            var cities = mockService.InitCities();

            var city = cities.Where(x => x.CityID.Equals(id));

            return city.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
