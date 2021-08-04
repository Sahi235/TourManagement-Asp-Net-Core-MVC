using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TourManagement.Database;
using TourManagement.Models;
using TourManagement.ViewModels;

namespace TourManagement.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger,
                              DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("DomesticTours")]
        public async Task<IActionResult> DomesticTours()
        {
            var latestTours = await
                    _context.Tours
                    .OrderByDescending(e => e.Id)
                    .Include(e => e.TourImages)
                    .ThenInclude(e => e.Image)
                    .Include(e => e.TourRegistrations)
                    .Include(e => e.City)
                    .ThenInclude(e => e.Country)
                    .Include(e => e.Services)
                    .ThenInclude(e => e.Service)
                    .Where(e => e.Capacity > e.TourRegistrations.Count)
                    .Where(e => e.Till > DateTime.Now)
                    .Where(e => e.City.Country.Name == "Azerbaijan")
                    .OrderByDescending(e => Guid.NewGuid())
                    .Take(2)
                    .ToListAsync();

            var query = await _context.Countries.Include(e => e.Cities).ThenInclude(e => e.Tours).AsTracking().ToListAsync();


            foreach (var entries in _context.ChangeTracker.Entries())
            {
                Console.WriteLine($"{entries.GetType().FullName} and state is {entries.State}");

                foreach (var member in entries.Members)
                {
                    Console.WriteLine($"{member.Metadata.Name}: {member.CurrentValue}");
                }
            }



            return View(latestTours);
        }

        [HttpGet]
        [Route("DomesticTour/{name}")]
        public async Task<IActionResult> DomesticTour(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return RedirectToAction(nameof(Index));
            }
            var tour = await _context.Tours
                .Include(e => e.TourImages)
                .ThenInclude(e => e.Image)
                .Include(e => e.Services)
                .ThenInclude(e => e.Service)
                .Include(e => e.City)
                .ThenInclude(e => e.Country)
                .Include(e =>e.TourRegistrations)
                .FirstOrDefaultAsync(e => e.TourName == name);
            return View(tour);
        }


        [HttpGet]
        [Route("DomesticCityTours/{cityName}")]
        public async Task<IActionResult> DomesticCityTours(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                return RedirectToAction(nameof(Index));
            }

            var tours = await
                _context.Tours
                    .OrderByDescending(e => e.Id)
                    .Include(e => e.TourImages)
                    .ThenInclude(e => e.Image)
                    .Include(e => e.TourRegistrations)
                    .Include(e => e.City)
                    .ThenInclude(e => e.Country)
                    .Include(e => e.Services)
                    .ThenInclude(e => e.Service)
                    .Where(e => e.Capacity > e.TourRegistrations.Count)
                    .Where(e => e.Till > DateTime.Now)
                    .Where(e => e.City.Name == cityName)
                    .OrderByDescending(e => Guid.NewGuid())
                    .ToListAsync();
            return View(tours);
        }

        [HttpGet]
        public async Task<IActionResult> OverSeasTours()
        {
            var tours = await
                _context.Tours
                    .OrderByDescending(e => e.Id)
                    .Include(e => e.TourImages)
                    .ThenInclude(e => e.Image)
                    .Include(e => e.TourRegistrations)
                    .Include(e => e.City)
                    .ThenInclude(e => e.Country)
                    .Include(e => e.Services)
                    .ThenInclude(e => e.Service)
                    .Where(e => e.Capacity > e.TourRegistrations.Count)
                    .Where(e => e.Till > DateTime.Now)
                    .Where(e => e.City.Country.Name != "Azerbaijan")
                    .OrderByDescending(e => Guid.NewGuid())
                    .Take(2)
                    .ToListAsync();
            return View(tours);
        }


        [HttpGet]
        [Route("OverSeasTour/{name}")]
        public async Task<IActionResult> OverSeasTour(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return RedirectToAction(nameof(Index));
            }
            var tour = await _context.Tours
                .Include(e => e.TourImages)
                .ThenInclude(e => e.Image)
                .Include(e => e.Services)
                .ThenInclude(e => e.Service)
                .Include(e => e.City)
                .ThenInclude(e => e.Country)
                .Include(e => e.TourRegistrations)
                .FirstOrDefaultAsync(e => e.TourName == name);
            return View(tour);
        }

        [HttpGet]
        [Route("OverSeasCityTours/{cityName}")]
        public async Task<IActionResult> OverSeasCityTours(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                return RedirectToAction(nameof(Index));
            }

            var tours = await
                _context.Tours
                    .OrderByDescending(e => e.Id)
                    .Include(e => e.TourImages)
                    .ThenInclude(e => e.Image)
                    .Include(e => e.TourRegistrations)
                    .Include(e => e.City)
                    .ThenInclude(e => e.Country)
                    .Include(e => e.Services)
                    .ThenInclude(e => e.Service)
                    .Where(e => e.Capacity > e.TourRegistrations.Count)
                    .Where(e => e.Till > DateTime.Now)
                    .Where(e => e.City.Name == cityName)
                    .OrderByDescending(e => Guid.NewGuid())
                    .ToListAsync();
            return View(tours);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Hotels()
        {
            return View();
        }

        [Route("SomePage")]
        public IActionResult SomePage()
        {
            var query = _context.Cities.Where(e => e.Name == "Baku");
            return View(query);
        }
    }
}
