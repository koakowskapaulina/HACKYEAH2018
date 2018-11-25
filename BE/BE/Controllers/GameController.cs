using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.ApiResult;
using BE.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                raffleService.DoRaffle();
                //var data = raffleService.DoRaffle();
                //return Json(new ApiResultGeneric<IEnumerable<int>>(data));
                return null;
            }
            catch (Exception ex)
            {
                return Json(ApiResultBase.GetByErrorCode(ErrorCode.InternalServerError));
            }
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
