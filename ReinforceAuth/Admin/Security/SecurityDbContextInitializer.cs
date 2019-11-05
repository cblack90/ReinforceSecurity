using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using ReinforceAuth.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ReinforceSystem.BLL;

namespace ReinforceAuth.Admin.Security
{
    public class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole { Name = "Administrators" });
            roleManager.Create(new IdentityRole { Name = "Registered Users" });

            var adminUser = new ApplicationUser
            {
                UserName = "WebAdmin",
                Email = "Elections2020@hackers.ru",
                EmailConfirmed = true
            };

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var result = userManager.Create(adminUser, "Pa$$word");

            if (result.Succeeded)
            {
                var adminId = userManager.FindByName("WebAdmin").Id;
                userManager.AddToRole(adminId, "Administrators");
            }

            var demoManager = new ReinforceController();
            var people = demoManager.ListStaff();
            foreach(var person in people)
            {
                var user = new ApplicationUser
                {
                    UserName = $"{person.FirstName}.{person.LastName}",
                    Email = $"{person.FirstName}.{person.LastName}@Demo.com",
                    EmailConfirmed = true,
                    StaffID = person.StaffId
                };
                result = userManager.Create(user, "Pa44word1");
                if (result.Succeeded)
                {
                    var userId = userManager.FindByName(user.UserName).Id;
                    userManager.AddToRole(userId, "Registered Users");
                }
            }

            base.Seed(context);
        }
    }
}