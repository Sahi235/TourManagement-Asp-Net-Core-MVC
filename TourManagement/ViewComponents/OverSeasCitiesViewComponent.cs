using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourManagement.Database;

namespace TourManagement.ViewComponents
{
    public class OverSeasCitiesViewComponent : ViewComponent
    {
        private readonly DatabaseContext _context;

        public OverSeasCitiesViewComponent(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cities = await
                _context.Cities
                    .Include(e => e.Tours)
                    .Include(e => e.Country)
                    .Where(e => e.Country.Name != "Azerbaijan")
                    .ToListAsync();
            return View(cities);
        }
    }
}
