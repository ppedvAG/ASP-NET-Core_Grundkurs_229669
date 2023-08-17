using AspNetClass.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AspNetClass.Web.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Produces("application/json")] //Hier den Rückgabetyp der API festlegen
	public class CustomerAPIController : ControllerBase
	{
		private readonly NorthwindContext _db;

        public CustomerAPIController(NorthwindContext db)
        {
			_db = db;
        }

		[HttpGet("/api/[controller]/AllCustomers")]  //Hier / am Anfang nicht vergessen
		public IEnumerable<Customer> Get()
		{
			return _db.Customers;
		}

		[HttpGet("/api/[controller]/Customer/{id}")]
		public Customer GetId(string id)
		{
			Customer cust = _db.Customers.FirstOrDefault(e => e.CustomerId == id);
			if (cust is null)
				NotFound();
			return cust;
		}


		//Postman: POST Request auf /api/CustomerAPI
		//Bei Body das Json eingeben
		//Typ auf Json umstellen
		[HttpPost()]
		public ActionResult<Customer> PostCustomer(Customer customer)
		{
			try
			{
				_db.Customers.Add(customer);
				_db.SaveChanges();
			}
			catch (Exception)
			{
				return BadRequest();
			}
			return CreatedAtAction(nameof(PostCustomer), customer);
		}
    }
}