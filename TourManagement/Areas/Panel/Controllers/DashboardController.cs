using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourManagement.Areas.Panel.ViewModels;
using TourManagement.Database;

namespace TourManagement.Areas.Panel.Controllers
{
    [Area("Panel")] 
    public class DashboardController : Controller
    {
        private readonly DatabaseContext _context;

        public DashboardController(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var registrations = await _context.Tours.Include(e => e.TourRegistrations).Select(c => new RegistrationApiVm()
            {
                title = c.TourName,
                start = c.From,
                end = c.Till.AddHours(12),
                color = c.TourRegistrations.Count <= c.Capacity ? "#546E7A" : "#FF7043",
                url = $"https://localhost:44379/panel/tour/tourdetails/" + c.Id,
            }).ToListAsync();

            var model = new DashboardVm()
            {
                ApiModel = registrations,
            };
            return View(model);
        }
    }
}
