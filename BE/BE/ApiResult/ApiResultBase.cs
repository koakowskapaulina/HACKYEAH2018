using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BE.ApiResult
{
    public class ApiResultBase
    {
        #region Properties
        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Error Error { get; set; }

        #endregion Properties

        #region Constructors

        public ApiResultBase(bool success = false)
        {
            Success = success;
            if (!success)
                Error = new Error { ErrorCode = (long)ErrorCode.InternalServerError, Messages = new[] { ErrorCode.InternalServerError.ToString() } };
        }

        public ApiResultBase(ErrorCode erroCode)
        {
            Success = false;
            Error = new Error { ErrorCode = (long)erroCode, Messages = new[] { erroCode.ToString() } };
        }

        #endregion Constructors


        #region Public methods

        public static ApiResultBase GetByErrorCode(ErrorCode erroCode)
        {
            return new ApiResultBase() { Error = new Error { ErrorCode = (long)erroCode, Messages = new[] { erroCode.ToString() } } };
        }

        #endregion Public methods
    }

    public class Error
    {
        [Required]
        public long? ErrorCode { get; set; }
        [Required]
        public string[] Messages { get; set; }
    }

    public enum ErrorCode
    {
        Success = 200,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        InternalServerError = 500,

        // Custom error code > 1000
        InvalidLogin = 1001,
        LoginExist = 1002,
        InvalidPassword = 1003
    }
}
