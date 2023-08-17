using Microsoft.AspNetCore.Mvc;

namespace AspNetClass.Web.Mvc.Controllers
{
	public class ErrorController : Controller
	{
		[ActionName("404")]
		public IActionResult Error404()
		{
			return View("404");
		}
	}
}
