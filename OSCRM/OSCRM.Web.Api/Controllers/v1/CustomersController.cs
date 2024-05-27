
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using OSCRM.Web.Api.Models.Categories.Exceptions;
using OSCRM.Web.Api.Models.Customers;
using OSCRM.Web.Api.Models.Customers.Exceptions;
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

                return ResponseHelper.CreateResponse(200, storageCust);
            }
            catch (CustomerValidationException custValidationException)
                 when (custValidationException.InnerException is NullCustomerException
                 or NullCategoryException or FailedToVerifyCategoryException)
            {
                return ResponseHelper.CreateResponse(400, custValidationException.InnerException);
            }
            catch (CustomerValidationException custValidationException)
            {
                return ResponseHelper.CreateResponse(400, custValidationException);
            }
            catch (CustomerSqlException custSqlException)
            {
                return ResponseHelper.CreateResponse(500, custSqlException);
            }
            catch (CustomerServiceException custServiceException)
            {
                return ResponseHelper.CreateResponse(500, custServiceException);
            }
        }
    }
}
