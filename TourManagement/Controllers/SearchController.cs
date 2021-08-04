using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourManagement.Database;

namespace TourManagement.Controllers
{
    [AllowAnonymous]
    public class SearchController : Controller
    {
        private readonly DatabaseContext _context;

        public SearchController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> SearchTour(string input)
        {
            var tours =
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
                    .OrderByDescending(e => Guid.NewGuid());
            if (string.IsNullOrWhiteSpace(input))
            {
                var toursList2 = await tours.ToListAsync();
                return View(toursList2);
            }

            var toursList = await tours.Where(e => EF.Functions.Like(e.TourName, $"%{input}%") || EF.Functions.Like(e.City.Name, input)).ToListAsync();
            return View(toursList);
        }
    }
}
