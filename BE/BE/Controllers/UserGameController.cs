using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.ApiResult;
using BE.Models;
using BE.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE.Controllers
{
    [Route("chcem/usergierki")]
    public class UserGameController : Controller
    {
        UserGamesService userGamesService;

        public UserGameController(UserGamesService _userGamesService)
        {
            userGamesService = _userGamesService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new ApiResultGeneric<IEnumerable<UserGames>>(userGamesService.GetUserGames()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(long id)
        {
            
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        [Route("nowa")]
        public void Post(int userId, string citiesIds)
        {
            userGameService.CreateUserGame(userId, citiesIds);
        }

    }
}
