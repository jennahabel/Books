using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookstore
{
    public class Startup
    {
        
        public IConfiguration Configuration { get; set; }
       
        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);
            });

            services.AddScoped<IBooksRepository, EFBooksRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "categories",
                    pattern: "{category}/Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("Pagination",
                    "Page{pageNum}",
                    new { Controller = "Home", action = "Index", pageNum = 1});

                endpoints.MapControllerRoute("type",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1});

             
                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });
        }
    }
}
