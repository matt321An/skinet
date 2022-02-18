using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager) 
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Matei",
                    Email = "matei@test.com",
                    UserName = "matei@test.com",
                    Address = new Address 
                    {
                        FirstName = "Matei",
                        LastName = "Anghel",
                        Street = "B-dul Titulescu",
                        City = "Craiova",
                        State = "Dolj",
                        ZipCode = "200154"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}