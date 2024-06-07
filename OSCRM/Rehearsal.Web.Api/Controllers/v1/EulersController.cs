
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Rehearsal.Web.Api.Services.v1.Eulers;
using Shared.Lib.AspNetCore.Mvc;

namespace Rehearsal.Web.Api.Controllers.v1
{
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class EulersController : ApiControllerBase
    {
        private readonly IEulerService _eulerService;

        public EulersController(IEulerService _eulerService) =>
            this._eulerService = _eulerService;

        /// <summary>
        /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23. Find the sum of all the multiples of 3 or 5 below 1000.
        /// </summary>
        /// <returns>Resultant message</returns>
        [HttpGet]
        [Route("Problem1")]
        public IActionResult Problem1()
        {
            var response = this._eulerService.SolveProblem1();

            return CreateResponse(200, response);
        }
    }
}
