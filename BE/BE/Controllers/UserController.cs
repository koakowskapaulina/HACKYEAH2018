using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE.ApiModels;
using BE.ApiResult;
using BE.Models;
using BE.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE.Controllers
{
    [Route("chcem/userkow")]
    public class UserController : Controller
    {
        IUserService userService;
        IMockService mockService;

        public UserController(IUserService _userService, IMockService _mockService)
        {
            userService = _userService;
            mockService = _mockService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = mockService.InitUsers();

                return Json(new ApiResultGeneric<IEnumerable<User>>(users));
            }
            catch
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
                User loggedUser = userService.checkUserCredentials(model.Email, password);
                if (loggedUser == null)
                {
                    return Json(ApiResultBase.GetByErrorCode(ErrorCode.InvalidLogin));
                }

                return Json(new ApiResultOk());
            }
            catch (Exception ex)
            {
                return Json(ApiResultBase.GetByErrorCode(ErrorCode.InternalServerError));
            }
        }
    }
}
