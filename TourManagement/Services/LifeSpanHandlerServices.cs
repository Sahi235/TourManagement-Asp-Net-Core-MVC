using Microsoft.Extensions.DependencyInjection;
using TourManagement.ImageServices;

namespace TourManagement.Services
{
    public static class LifeSpanHandlerServices
    {
        public static void AddLifeSpanHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<IImageHandler, ImageHandler>();
            services.AddScoped<IImageWriter, ImageWriter>();
        }
    }
}
