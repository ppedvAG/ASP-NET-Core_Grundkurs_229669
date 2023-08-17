using AspNetClass.DataAccess.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace AspNetClass.Web.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Services to DI Container => Configuring Dependency Injection
            builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDb")));
            
            // Add MVC Pattern to the app
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

			app.UseStatusCodePagesWithRedirects("/Error/{0}");

			app.UseExceptionHandler(builder =>
			{
				builder.Run(async context => //context: Die HTTP Message
				{
					context.Response.StatusCode = (int) HttpStatusCode.InternalServerError; //Neuen StatusCode schreiben

					IExceptionHandlerFeature exception = context.Features.Get<IExceptionHandlerFeature>(); //Das Exception Objekt holen

					await context.Response.WriteAsync(exception.Error.Message); //Die Exception in die Response schreiben
				});
			});

            app.Run();
        }
    }
}