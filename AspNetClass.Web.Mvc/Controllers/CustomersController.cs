using AspNetClass.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

		[HttpPost]
		public IActionResult Create(Customer customer)
		{
			if (ModelState.IsValid) //Prüfe, ob der State von EntityFramework gleich ist mit dem State der Entities die bereits herausgenommen wurden
			{
				if (!_db.Customers.Select(e => e.CustomerId).Contains(customer.CustomerId)) //Prüfe ob der Datensatz bereits existiert
				{
					_db.Customers.Add(customer);
					_db.SaveChanges();
				}
			}

			return View("Customers");
		}

		[HttpGet]
		public IActionResult Edit(string id)
		{
			Customer cust = _db.Customers.FirstOrDefault(e => e.CustomerId == id);
			if (cust != null)
			{
				return View(nameof(Edit), cust);
			}
			return StatusCode(500); //Für beliebige StatusCodes kann die Methode StatusCode(<Code>) verwendet werden
		}

		[HttpPost]
		public IActionResult Edit(Customer cust)
		{
			if (!ModelState.IsValid)
				return NotFound();

			_db.Attach(cust).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			_db.SaveChanges();
			return View("Customers", _db.Customers);
		}

		[HttpGet]
		public IActionResult Delete(string id)
		{
			Customer cust = _db.Customers.FirstOrDefault(e => e.CustomerId == id);
			if (cust != null)
			{
				return View(nameof(Delete), cust);
			}
			return View("Customers", _db.Customers);
		}

		[HttpPost]
		[ActionName("Delete")] //ActionName: Erlaubt umbenennen der Methode damit sie zur View passt
		public IActionResult DeleteConfirm(string id)
		{
			Customer cust = _db.Customers.FirstOrDefault(e => e.CustomerId == id);
			if (cust == null)
				return NotFound();

			_db.Customers.Remove(cust);
			_db.SaveChanges();
			return View("Customers", _db.Customers);
		}

		[HttpGet]
		public IActionResult Details(string id)
		{
			Customer cust = _db.Customers.FirstOrDefault(e => e.CustomerId == id);
			if (cust == null)
				return NotFound();
			return View("Details", cust);
		}
	}
}