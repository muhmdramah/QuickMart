using Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class ApplicationIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    DisplayName = "Mohammed",
                    Email = "mohammedrammah83@gmail.com",
                    UserName = "muhmdramah",
                    Address = new Address()
                    {
                        FirstName = "Mohammed",
                        LastName = "Rammah",
                        Street = "Unknown",
                        City = "Shiekh Zayed",
                        State = "Giza",
                        ZipCode = "25122002"
                    }
                };
                await userManager.CreateAsync(user, "P@ssw0rd");
            }
        }
    }
}
