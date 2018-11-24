using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.ApiModels;
using BE.Helpers;
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
        [Route("login")]
        public void Login(LoginModel model)
        {
            try
            {
                var mockService = new MockService();
                var users = mockService.InitUsers();

                var usersList = users;

                //return JsonConvert.SerializeObject(usersList);
            }
            catch (Exception ex)
            {
                LogHelper.Logger.Error(ex);
                //return null;
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
