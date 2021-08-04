using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace TourManagement.Services
{
    public static class ExtraConfigurations
    {
        public static void AddExtraConfigurations(this IServiceCollection services)
        {
            services.Configure<RouteOptions>(c =>
            {
                c.LowercaseUrls = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Home/AccessDenied");
                options.LoginPath = new PathString("/Account/Login");
            });
        }
    }
}
