﻿using System;
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

        [HttpGet]
        public IActionResult Get()
        {                 
            try
            {
                return Json(new ApiResultGeneric<IEnumerable<City>>(mockService.GetCities()));
            }
            catch (Exception ex)
            {
                return Json(ApiResultBase.GetByErrorCode(ErrorCode.InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = mockService.GetCityById(mockService.GetCities(), id);
                return Json(new ApiResultGeneric<City>(data));
            }
            catch (Exception ex)
            {
                return Json(ApiResultBase.GetByErrorCode(ErrorCode.InternalServerError));
            }
        }
    }
}
