using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TourManagement.Database;

namespace TourManagement.Services
{
    public static class DatabaseServices
    {
        public static void AddDatabaseService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
