using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourManagement.Database;

namespace TourManagement.ViewComponents
{
    public class ToursViewComponent : ViewComponent
    {
        private readonly DatabaseContext _context;

        public ToursViewComponent(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var latestTours = await
                _context.Tours
                    .OrderByDescending(e => e.Id)
                    .Include(e => e.TourImages)
                    .ThenInclude(e => e.Image)
                    .Include(e => e.TourRegistrations)
                    .Include(e => e.City)
                    .Include(e => e.Services)
                    .ThenInclude(e => e.Service)
                    .Where(e => e.TourRegistrations.Count < e.Capacity)
                    .Take(4)
                    .ToListAsync();
            return View(latestTours);
        }
    }
}
