

using Microsoft.AspNetCore.Mvc;
using Rehearsal.Web.Api.Services.v1.Items;
using Shared.Lib.AspNetCore.Mvc;

namespace Rehearsal.Web.Api.Controllers.v1
{
    [Route("api/v{version:apiVersion}/items")]
    [ApiController]
    public class ItemsController : ApiControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService _itemService) =>
            this._itemService = _itemService;

        #region random-and-yield
        [HttpGet]
        [Route("random-and-yield")]
        public ActionResult Random_Yield()
        {
            var response = this._itemService.Random_Yield();

            return CreateResponse(200, response);
        }
        #endregion

        #region spread-operator
        [HttpGet]
        [Route("spread-operator")]
        public ActionResult SpreadOperator()
        {
            var response = this._itemService.SpreadOperator();

            return CreateResponse(200, response);
        }
        #endregion

        #region minimum-null-statement
        [HttpGet]
        [Route("minimum-null-statement")]
        public ActionResult MinimumNullStatement()
        {
            var response = this._itemService.MinimumNullStatement();

            return CreateResponse(200, response);
        }
        #endregion

        #region jsonNode-and-jsonArray
        [HttpGet]
        [Route("jsonNode-and-jsonArray")]
        public ActionResult JsonNode_JsonArray()
        {
            var response = this._itemService.JsonNode_JsonArray();

            return CreateResponse(200, response);
        }
        #endregion

        #region random-shuffle
        [HttpGet]
        [Route("random-shuffle")]
        public ActionResult RandomShuffle()
        {
            var response = this._itemService.RandomShuffle();

            return CreateResponse(200, response);
        }
        #endregion
    }
}
