
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace OSCRM.Web.Api.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ValuesController : ControllerBase
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

            return Ok(connetionSrings);
        }
    }
}
