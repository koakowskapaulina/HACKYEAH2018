using System.Linq;
using BE.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BE.Controllers
{
    [Route("chcem/miasta")]
    public class CityController : Controller
    {
        IMockService mockService;

        public CityController(IMockService _mockService)
        {
            mockService = _mockService;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {            
            return JsonConvert.SerializeObject(mockService.GetCities());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {            
            return JsonConvert.SerializeObject(mockService.GetCityById(mockService.InitCities(), id));
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
