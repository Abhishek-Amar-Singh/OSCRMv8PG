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

        #region frozen-dictionary
        // Advantages
        // - High Performance: Provides high performance in lookup operations after the dictionary is frozen.
        // - Stability: Once the dictionary is frozen, it cannot be modified, ensuring data stability.
        // Disadvantages
        // - Immutability after Freezing: Once frozen, no modifications can be made.
        // - Specific Use Case: It is only useful in scenarios where no frequent changes are required after the dictionary is created.
        [HttpGet]
        [Route("frozen-dictionary")]
        public ActionResult FrozenDictCollection()
        {
            var response = this._itemService.FrozenDictCollection();

            return CreateResponse(200, response);
        }
        #endregion

        #region frozen-set
        // Why Use Frozenset?
        // - Frozenset ensures that your collection of items remains constant throughout the lifecycle of your application,
        // providing stability and predictability. This is particularly useful in multi-threaded applications where data
        // consistency is important.
        [HttpGet]
        [Route("frozen-set")]
        public ActionResult FrozenSetCollection()
        {
            var response = this._itemService.FrozenSetCollection();

            return CreateResponse(200, response);
        }
        #endregion

        #region throw-and-throwEx
        [HttpGet]
        [Route("throw-and-throwEx")]
        public ActionResult ThrowAndThrowEx(string parameter)
        {
            try
            {
                var response = this._itemService.Foo(parameter);

                return CreateResponse(200, (object)response);//--since bool is struct so generic type should be of reference type.
            }
            catch (Exception ex)
            {
                return CreateResponse(400, ex);
            }
        }
        #endregion


    }
}
