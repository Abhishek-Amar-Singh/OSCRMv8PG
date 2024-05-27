
using Microsoft.AspNetCore.Mvc;

namespace Shared.Lib.Models
{
    public class Response<T> where T : class
    {
        public int status { get; set; } = 200;
        public string message { get; set; } = "success";
        public T? data { get; set; }
    }

    public class ResponseHelper
    {
        public static ObjectResult CreateResponse<T>(int status, T data) where T : class
        {
            Response<T> response = new()
            {
                data = data
            };

            if (status != 200)
            {
                response.status = status;
                response.message = "failed";
            }

            return new ObjectResult(response) { StatusCode = response.status };
        }
    }
}
