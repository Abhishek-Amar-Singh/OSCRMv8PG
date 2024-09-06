//using Microsoft.AspNetCore.Mvc;
//using Rehearsal.Web.Api.Services.Items;

//namespace Rehearsal.Web.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ItemController : ControllerBase
//    {
//        private readonly IItemService _itemService;

//        public ItemController(IItemService _itemService) =>
//            this._itemService = _itemService;

//        [HttpGet]
//        [Route("basic-py")]
//        public ActionResult BasicPy()
//        {
//            var tuple = this._itemService.BasicPy();

//            return 
//                (tuple.Item3 is not null) ?
//                File(tuple.Item3, "application/pdf", "de9e6db6-54aa-4802-8842-f1e83dfd1f30_NDA.pdf") :
//                NotFound();

//            /* 
//             * File(tuple.Item3, "application/octet-stream", "de9e6db6-54aa-4802-8842-f1e83dfd1f30_NDA.pdf")
//             * It will not open a blob properly but it will download your pdf
//            */
//        }
//    }
//}
