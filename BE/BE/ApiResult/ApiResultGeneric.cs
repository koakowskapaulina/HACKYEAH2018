using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.ApiResult
{
    public class ApiResultGeneric : ApiResultBase
    {
        /// <summary>
        /// Contains result object when Success = true
        /// </summary>
        public string Data { get; set; }


        public ApiResultGeneric() : base(false)
        {

        }

        public ApiResultGeneric(string data) : base(true)
        {
            Data = data;
        }
    }
}
