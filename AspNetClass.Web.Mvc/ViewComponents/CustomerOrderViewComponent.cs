using AspNetClass.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetClass.Web.Mvc.ViewComponents;

public class CustomerOrderViewComponent : ViewComponent
{
	//ViewComponent: "Partielle View", die auch Code behind haben kann
	//4 Teile:
	//ViewComponents/Class.cs: Backend Code
	//Shared/Components/CustomerOrder/Default.cshtml: Die View
	//Einbinden in die View mittels @await Component.InvokeAsync
	//Hier die InvokeAsync Funktion implementieren

	private readonly NorthwindContext _db;

	public CustomerOrderViewComponent(NorthwindContext context)
	{
		_db = context;
	}

	public async Task<IViewComponentResult> InvokeAsync(string customerId)
	{
		IQueryable<Order> orders = _db.Orders.Where(e => e.CustomerId == customerId);
		return View("Default", await orders.ToListAsync());
	}
}
