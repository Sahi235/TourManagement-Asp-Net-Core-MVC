using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;

namespace TourManagement.Services
{
    public static class CookieAndCompressionServices
    {
        public static void AddCookieAndCompressionServices(this IServiceCollection service)
        {
            service.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Home/AccessDenied");
                options.LoginPath = new PathString("/Accounts/Login");
            });
            service.AddResponseCompression(c => c.Providers.Add<GzipCompressionProvider>());
        }
    }
}
