using System;
using System.Collections;
using System.Collections.Generic;
using BE.ApiResult;
using BE.Models;
using BE.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new ApiResultGeneric<IEnumerable<UserGames>>(userGamesService.GetUserGames()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Json(new ApiResultGeneric<IEnumerable<UserGames>>(userGamesService.GetUserGames(id)));
        }

        [HttpPost]
        [Route("nowa")]
        public void Post(int userId, string citiesIds)
        {
            userGamesService.CreateUserGame(userId, citiesIds);
        }
    }
}
