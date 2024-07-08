using Core.Web.App.Models.V2C;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.App.Controllers
{
    public class PassDataController : Controller
    {
        #region Controller to View
        //Pass Data from Controller to View
        //all below 3 present in Controller-base-class
        //View Data--Dictionary Type,other than string do explicit casting,available only in  ActionResult-method where it is declared(initialized)
        //View Bag--Dynamic,no explicit typeCasting,available only in  ActionResult-method where it is declared(initialized)
        //Temp Data--Dictionary Type,available in all ActionResult-methods but only for one request
        //ViewData,ViewBag,TempData--which is not binded with the model
        public ActionResult C2V()
        {
            ViewData["viewdata"] = "data comes from ViewData.";
            ViewBag.viewbag = "data comes from ViewBag.";
            TempData["tempdata"] = "data comes from TempData.";
            return View();
        }
        public ActionResult C2V_Contact()
        {
            TempData.Keep("tempdata");//--to view it again so keep it otherwise only one time it will be visible.
            return View();
        }
        public ActionResult C2V_Contact2()
        {
            return View();
        }
        #endregion

        #region View to Controller
        //Get data from view to controller
        //1.Using a parameter
        //2.IFormCollection---as parameter
        //3.Product---as parameter

        [HttpGet]
        public IActionResult V2C() => View();

        //1)
        //[HttpPost]
        //public IActionResult V2C(string id, string name)
        //{
        //    int productId = int.Parse(id);
        //    string productName = name;
        //    return Content($"using parameters -> [Id::{productId}, Name::{productName}]");
        //}

        //2)
        //[HttpPost]
        //public IActionResult V2C(IFormCollection fc)
        //{
        //    long productId = long.Parse(fc["id"]!);
        //    string productName = fc["Name"]!;
        //    return Content($"using IFormCollection -> [Id::{productId}, Name::{productName}]");
        //}

        //3)
        [HttpPost]
        public IActionResult V2C(Product p)
        {
            long productId = p.id;
            string productName = p.name;
            return Content($"using object({nameof(Product)}) -> [Id::{productId}, Name::{productName}]");
        }
        #endregion
    }
}
