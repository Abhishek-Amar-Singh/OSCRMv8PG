
using Asp.Versioning;
using OSCRM.Web.Api.Models.Customers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using OSCRM.Web.Api.Models.Customers;
using OSCRM.Web.Api.Services.v1.Customers;
using Shared.Lib.Models;

namespace OSCRM.Web.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService _customerService) =>
            this._customerService = _customerService;

        [HttpPost]
        public async ValueTask<ActionResult> PostCustomerAsync([FromBody] CreateCustomer dto)
        {
            try
            {
                var storageCust = await this._customerService.CreateCustomerAsync(dto);

                return CreateResponse(200, storageCust);
            }
            catch (CustomerValidationException custValidationException)
                 when (custValidationException.InnerException is NullCustomerException)
            {
                return CreateResponse(400, custValidationException.InnerException);
            }
            catch (CustomerValidationException custValidationException)
            {
                return CreateResponse(400, custValidationException);
            }
            catch (CustomerServiceException custServiceException)
            {
                return CreateResponse(500, custServiceException);
            }
        }

        private ObjectResult CreateResponse<T>(int status, T data) where T : class
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

            return StatusCode(response.status, response);
        }
    }
}
