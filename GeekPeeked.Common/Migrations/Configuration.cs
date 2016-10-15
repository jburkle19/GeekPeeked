using System;
using System.Linq;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GeekPeeked.Common.Models;
using GeekPeeked.Common.Configuration;

namespace GeekPeeked.Common.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GeekPeekedDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GeekPeekedDbContext context)
        {
            try
            {
                #region AspNetUser and RoleManager Initialization

                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new GeekPeekedDbContext()));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                IdentityResult roleResult;
                string roleName = "Administrator";

                if (!roleManager.RoleExists(roleName))
                    roleResult = roleManager.Create(new IdentityRole(roleName));

                var user = context.Users.Where(x => x.UserName.Equals("jburkle19@gmail.com")).FirstOrDefault();

                if (user == null)
                {
                    user = new ApplicationUser()
                    {
                        UserName = "jburkle19@gmail.com",
                        Email = "jburkle19@gmail.com",
                        FirstName = "John",
                        LastName = "Burkle",
                        PhoneNumber = "330-400-8169",
                        CreatedDate = DateTime.Now
                    };

                    manager.Create(user, CoreConfiguration.SeedAdminPassword);
                }

                manager.AddToRole(user.Id, roleName);

                #endregion AspNetUser and RoleManager Initialization
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Failed to run Seeds: {0}", e.Message));
            }
        }
    }
}
