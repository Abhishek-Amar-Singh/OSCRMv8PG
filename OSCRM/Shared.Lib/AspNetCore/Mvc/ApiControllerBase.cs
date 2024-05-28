
using Microsoft.AspNetCore.Mvc;
using Shared.Lib.Models;

namespace Shared.Lib.AspNetCore.Mvc
{
    public class ApiControllerBase : ControllerBase
    {
        public ObjectResult CreateResponse<T>(int status, T data) where T : class
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
