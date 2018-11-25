using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE.Controllers
{
    [Route("chcem/usergierki")]
    public class UserGameController : Controller
    {
        UserGamesService userGameService;

        public UserGameController(UserGamesService _userGameService)
        {
            userGameService = _userGameService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<controller>
        [HttpGet("{userId}/{citiesIds}")]
        public void Get(int userId, string citiesIds)
        {
            userGameService.CreateUserGame(userId, citiesIds);
        }

    }
}
