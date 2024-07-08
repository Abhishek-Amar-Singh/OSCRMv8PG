using Core.Web.App.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Lib.AspNetCore.Sessions;
using System.Diagnostics;

namespace Core.Web.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionManager _sessionManager;

        public HomeController(
            ILogger<HomeController> _logger,
            ISessionManager _sessionManager)
        {
            this._logger = _logger;
            this._sessionManager = _sessionManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegenerateSession()
        {
            this._sessionManager.setSessionOfString("UserName", "Abhishek");
            this._sessionManager.setSessionOfInt32("uid", 123);
            return RedirectToAction("Index");
        }

        public IActionResult GetSessionData()
        {
            if (this._sessionManager.IsUserAuthorized("uid"))
            {
                ViewBag.uname = this._sessionManager.getSessionOfString("UserName");
                ViewBag.uid = this._sessionManager.getSessionOfInt32("uid");
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
