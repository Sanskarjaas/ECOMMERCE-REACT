using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Sanskar",
                    Email = "Sanskar@gmail.com",
                    UserName = "Sanskar.com",
                    Address = new Address
                    {
                        FirstName = "Sanskar",
                        LastName = "Jaiswal",
                        Street = "23",
                        City = "Bengaluru",
                        State = "Karnataka",
                        ZipCode = "758035"


                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }

}