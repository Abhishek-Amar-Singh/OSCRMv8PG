
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shared.Lib.AspNetCore.Mvc;

namespace OSCRM.Web.Api.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ValuesController : ApiControllerBase
    {
        [HttpGet]
        [Route("GetConnectionStrings")]
        public IActionResult GetConnectioStrings()
        {
            var connetionSrings = new
            {
                OSCRMDbConnection = string.Empty,
                RehearsalDbConnection = string.Empty,
                LakeMasterDbConnection = string.Empty
            };

            return CreateResponse(200, connetionSrings);
        }
    }
}
