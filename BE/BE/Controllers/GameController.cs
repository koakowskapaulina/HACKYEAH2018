using BE.ApiResult;
using BE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BE.Controllers
{
    [Route("chcem/losowanko")]
    public class GameController : Controller
    {
        IRaffleService raffleService;

        public GameController(IRaffleService _raffleService)
        {
            raffleService = _raffleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(new ApiResultGeneric<IEnumerable<int>>(raffleService.DoRaffle()));
            }
            catch (Exception ex)
            {
                return Json(ApiResultBase.GetByErrorCode(ErrorCode.InternalServerError));
            }
        }
    }
}
