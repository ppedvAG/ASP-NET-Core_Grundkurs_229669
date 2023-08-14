using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace AspNetClass.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Northwind Traders Management Portal";
            //return Content("<html><head><title>Welcome to MVC</title></head><body><h2>Welcome to my Site</h2></body></html>", "text/html");
            return View();
        }

        public IActionResult Test()
        {
            return Content("Hi from the Test Action Method");
        }
    }
}
