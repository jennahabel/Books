using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//Set up seed data for passwords

namespace Bookstore.Models
{
    public static class IdentitySeedData
    {
        //set constants that will not change - allows us to reuse it and not worry if it gets modified
        private const string adminUser = "Admin";
        private const string adminPassword = "Password123456!";

        //Create an instance of the context file
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDBContext>();

            //Any migrations that need to be run? Then run it
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            //sets up a user
            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            //creates a new user if it is null
            if (user == null)
            {
                user = new IdentityUser(adminUser);
                user.Email = "adminUser@mail.com";
                user.PhoneNumber = "555-1234";

                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
