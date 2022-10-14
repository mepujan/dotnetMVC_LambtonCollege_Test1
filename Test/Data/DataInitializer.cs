using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.Data
{
    public class DataInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {

            //Create an "Admin" Role
            if(!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);
            }

            //Create a test user, set their Country to Canada, date of birth to Jan 01 2000, user name and email to test@test.com and password to testing1234'

            var userStore = new UserStore<ApplicationUser>(context);    
            var userManager = new UserManager<ApplicationUser>(userStore);
            var testUser = new ApplicationUser {
                UserName = "test@test.com",
                Email = "test@test.com",
                Country = "Canada",
                DateOfBith = DateTime.Parse("2000-01-01")
                };

            var userCreation = userManager.Create(testUser, "testing1234");

            if (userCreation.Succeeded)
            {
                userManager.AddToRole(testUser.Id, "Admin");
            }


            //Create two Items's, One item isOnSale must be true, the other must be false, and add them to the database

            context.Items.Add(new Item
            {
                Cost = 200,
                Name = "Database Book",
                isOnSale = true,
            });


            context.Items.Add(new Item
            {
                Cost = 80,
                Name = "Bicycle",
                isOnSale = false,
            });
            base.Seed(context);
        }
    }
}