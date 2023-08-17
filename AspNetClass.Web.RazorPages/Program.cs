using AspNetClass.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetClass.Web.RazorPages;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add Services to DI Container => Configuring Dependency Injection
		builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDb")));

		// Add services to the container.
		builder.Services.AddRazorPages();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();

		app.MapRazorPages();

		app.Run();

		//builder.Services.AddRazorPages(); und app.MapRazorPages(); wird benötigt
	}
}