using System;
using System.Linq;
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
        [HttpGet]
        public string Get()
        {
            var mockService = new MockService();
            var users = mockService.InitUsers();

            var usersList = users;

            return JsonConvert.SerializeObject(usersList);
        }

        [HttpPost]
        [Route("logowanko")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {
                var mockService = new MockService();
                var users = mockService.InitUsers();

                User loggedUser = users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                if (loggedUser == null)
                {
                    return Json(ApiResultBase.GetByErrorCode(ErrorCode.InvalidLogin));
                }

                return Json(new ApiResultOk());
            }
            catch
            {
                return Json(ApiResultBase.GetByErrorCode(ErrorCode.InternalServerError));
            }
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
