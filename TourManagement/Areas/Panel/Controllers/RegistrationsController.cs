using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourManagement.Database;

namespace TourManagement.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class RegistrationsController : Controller
    {
        private readonly DatabaseContext _context;

        public RegistrationsController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _context.TourRegistrations.Include(e => e.Client).Include(e => e.Payment)
                .Include(e => e.Tour).ThenInclude(e => e.City).ToListAsync();
            if (model != null) return View(model);
            ViewData["Message"] = "Registration was not found, either it was deleted or it is being edited";
            return View("NotFound");

        }


        [HttpGet]
        public async Task<IActionResult> RegistrationDetails(Guid id)
        {
            var model = await _context.TourRegistrations.Include(e => e.Client).Include(e => e.Payment)
                .Include(e => e.Tour).ThenInclude(e => e.City).SingleOrDefaultAsync(e => e.Id == id);
            if (model != null) return View(model);
            ViewData["Message"] = "Registration was not found, either it was deleted or it is being edited";
            return View("NotFound");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteRegistration(Guid? id)
        {
            var model = await _context.TourRegistrations.Include(e => e.Client).Include(e => e.Payment)
                .Include(e => e.Tour).ThenInclude(e => e.City).SingleOrDefaultAsync(e => e.Id == id.Value);
            if (model != null) return View(model);
            ViewData["Message"] = "Registration was not found, either it was deleted or it is being edited";
            return View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRegistration(Guid id)
        {
            var model = await _context.TourRegistrations.FirstOrDefaultAsync(e => e.Id == id);
            if (model == null)
            {
                ViewData["Message"] = "Registration was not found, either it was deleted or it is being edited";
                return View("NotFound");
            }

            _context.TourRegistrations.Remove(model);
            var result = await _context.SaveChangesAsync();
            if (result >= 1) return RedirectToAction(nameof(Index));
            ModelState.AddModelError(string.Empty, "Something went wrong");
            return View(model);

        }
        
    }
}
