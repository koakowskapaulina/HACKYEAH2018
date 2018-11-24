using System.Linq;
using System.Threading.Tasks;
using BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BE.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        [HttpGet]
        public string Get()
        {
            var mockService = new MockService();
            var users = mockService.InitCities();

            var usersList = users;

            return JsonConvert.SerializeObject(usersList);
        }
    }
}
