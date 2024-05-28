
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shared.Lib.AspNetCore.Mvc;

namespace OSCRM.Web.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ValuesController : ApiControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration _configuration) => this._configuration = _configuration;

        [HttpGet]
        [Route("GetConnectionStrings")]
        public IActionResult GetConnectionStrings()
        {
            var connetionSrings = new
            {
                OSCRMDbConnection = _configuration.GetConnectionString("OSCRMDbConnection"),
                RehearsalDbConnection = _configuration.GetConnectionString("RehearsalDbConnection"),
                LakeMasterDbConnection = _configuration.GetConnectionString("LakeMasterDbConnection")
            };

            return CreateResponse(200, connetionSrings);
        }
    }
}
