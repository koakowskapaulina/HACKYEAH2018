using System;
using System.Collections.Generic;
using System.Text;
using BE.ApiModels;
using BE.ApiResult;
using BE.Models;
using BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("chcem/userkow")]
    public class UserController : Controller
    {
        IUserService userService;

        public UserController(IUserService _userService, IMockService _mockService)
        {
            userService = _userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = userService.GetUsers();

                return Json(new ApiResultGeneric<IEnumerable<User>>(users));
            }
            catch (Exception ex)
            {
                return Json(ApiResultBase.GetByErrorCode(ErrorCode.InternalServerError));
            }
        }

        [HttpPost]
        [Route("logowanko")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {
                var password = Encoding.UTF8.GetString(Convert.FromBase64String(model.Password));
                User loggedUser = userService.CheckUserCredentials(model.Email, password);
                if (loggedUser == null)
                {
                    return Json(ApiResultBase.GetByErrorCode(ErrorCode.InvalidLogin));
                }

                return Json(new ApiResultGeneric<long>(loggedUser.UserID));
            }
            catch (Exception ex)
            {
                return Json(ApiResultBase.GetByErrorCode(ErrorCode.InternalServerError));
            }
        }
    }
}
