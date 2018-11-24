using System.Collections.Generic;
using System.Linq;
using BE.ApiResult;
using BE.Models;
using BE.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BE.Controllers
{
    [Route("chcem/miasta")]
    public class CityController : Controller
    {
        IMockService mockService;

        public CityController(IMockService _mockService)
        {
            mockService = _mockService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(new ApiResultGeneric<IEnumerable<City>>(mockService.GetCities()));
            }
            catch
            {
                return Json(ApiResultBase.GetByErrorCode(ErrorCode.InternalServerError));
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = mockService.GetCityById(mockService.GetCities(), id);
                return Json(new ApiResultGeneric<City>(data));
            }
            catch
            {
                return Json(ApiResultBase.GetByErrorCode(ErrorCode.InternalServerError));
            }
        }
    }
}
