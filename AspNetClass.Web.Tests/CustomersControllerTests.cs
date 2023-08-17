using AspNetClass.DataAccess.Models;
using AspNetClass.Web.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AspNetClass.Web.Tests
{
	[TestClass]
	public class CustomersControllerTests
	{
		[TestMethod]
		public void TestIndex()
		{
			NorthwindContext context = new NorthwindContext();
			CustomersController controller = new CustomersController(context);
			IActionResult result = controller.Index();
			ViewResult res = result as ViewResult;
			Assert.AreEqual(context.Customers.ToList(), res.ViewData.Model);
		}
	}
}