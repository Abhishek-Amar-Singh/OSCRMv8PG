
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using OSCRM.Web.Api.Models.Categories.Exceptions;
using OSCRM.Web.Api.Models.Customers;
using OSCRM.Web.Api.Models.Customers.Exceptions;
using OSCRM.Web.Api.Services.v1.Customers;
using Shared.Lib.AspNetCore.Mvc;
using Shared.Lib.AppLogs;

namespace OSCRM.Web.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ServiceFilter(typeof(AppLogger))]
    public class CustomersController : ApiControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService _customerService) =>
            this._customerService = _customerService;

        [HttpPost]
        public async ValueTask<ActionResult> PostCustomerAsync([FromBody] CreateCustomer dto)
        {
            try
            {
                DisplayCustomer storageCust = await this._customerService.CreateCustomerAsync(dto);

                return CreateResponse(200, storageCust);
            }
            catch (CustomerValidationException custValidationException)
                 when (custValidationException.InnerException is NullCustomerException
                 or NullCategoryException or FailedToVerifyCategoryException or InvalidCustomerException)
            {
                return CreateResponse(400, custValidationException.InnerException);
            }
            catch (CustomerValidationException custValidationException)
                 when (custValidationException.InnerException is AlreadyExistsCustomerException)
            {
                return CreateResponse(409, custValidationException.InnerException);
            }
            catch (CustomerValidationException custValidationException)
            {
                return CreateResponse(400, custValidationException);
            }
            catch (CustomerSqlException custSqlException)
            {
                return CreateResponse(500, custSqlException);
            }
            catch (CustomerServiceException custServiceException)
            {
                return CreateResponse(500, custServiceException);
            }
        }

        [HttpGet]
        public ActionResult GetAllCustomers()
        {
            try
            {
                var storageCustomers = this._customerService.RetrieveAllCustomers();

                return CreateResponse(200, storageCustomers);
            }
            catch (CustomerSqlException custSqlException)
            {
                return CreateResponse(500, custSqlException);
            }
            catch (CustomerServiceException custServiceException)
            {
                return CreateResponse(500, custServiceException);
            }
        }
    }
}
