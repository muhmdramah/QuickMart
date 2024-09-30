using Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace QuickMart_Ecommerce_API.Extentions
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUser> FindUserByClaimsPrincipalWithAddress
            (this UserManager<ApplicationUser> userManager, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            var data = await userManager.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);

            return data;
        }

        public static async Task<ApplicationUser> FindUserByEmailFromClaimsPrincipal
            (this UserManager<ApplicationUser> userManager, ClaimsPrincipal user)
        {
            var data = await userManager.Users.SingleOrDefaultAsync(x => x.Email == user.FindFirstValue(ClaimTypes.Email));

            return data;
        }
    }
}
