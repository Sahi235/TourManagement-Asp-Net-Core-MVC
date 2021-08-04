using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TourManagement.Database;
using TourManagement.Models;

namespace TourManagement.Services
{
    public static class IdentityServices
    {
        public static void AddIdentityServices(this IServiceCollection service)
        {
            service.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<DatabaseContext>();
            service.AddAuthentication();
            service.AddAuthorization();
        }

    }
}
