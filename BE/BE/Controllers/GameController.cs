using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE.Controllers
{
    [Route("chcem/losowanko")]
    public class GameController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            var raffleService = new RaffleService();          

            return JsonConvert.SerializeObject(raffleService.DoRaffle());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
