using AspNetClass.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetClass.Web.Mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly NorthwindContext _db;

        public CustomersController(NorthwindContext context)
        {
            _db = context;

        }

        [HttpGet]
        public IActionResult Index()
        {
            var customers = _db.Customers.ToList();

            return View("Customers", customers);
        }

		[HttpGet]
		public IActionResult Create()
		{
			return View(nameof(Create));
		}
	}
}