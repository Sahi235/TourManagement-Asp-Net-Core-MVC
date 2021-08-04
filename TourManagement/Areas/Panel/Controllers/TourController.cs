using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TourManagement.Areas.Panel.ViewModels;
using TourManagement.Constants;
using TourManagement.Database;
using TourManagement.ImageServices;
using TourManagement.Models;

namespace TourManagement.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[Area]/[Controller]/[Action]/{id?}")]
    public class TourController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IImageHandler _imageHandler;

        public TourController(DatabaseContext context,
                              IImageHandler imageHandler)
        {
            _context = context;
            _imageHandler = imageHandler;
        }


        public async Task<IActionResult> Index()
        {
            var tours = await _context.Tours.Include(e => e.TourRegistrations).Include(c => c.City)
                .Include(e => e.Services).Include(e => e.City).ToListAsync();

            return View(tours);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Services"] = new MultiSelectList(await _context.Services.ToListAsync(), nameof(Service.Id), nameof(Service.Name));
            ViewData["Cities"] = new SelectList(await _context.Cities.ToListAsync(),nameof(City.Id),nameof(City.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTourVm model)
        {
            ViewData["Services"] = new MultiSelectList(await _context.Services.ToListAsync(), nameof(Service.Id), nameof(Service.Name), model.ServicesId);
            ViewData["Cities"] = new SelectList(await _context.Cities.ToListAsync(), nameof(City.Id), nameof(City.Name), model.CityId);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Images.Count < 1)
            {
                ModelState.AddModelError(string.Empty, "Image can not be empty. Please add at least one image for tour");
                return View(model);
            }

            if (!await _context.Cities.AnyAsync(c => c.Id == model.CityId))
            {
                ModelState.AddModelError(string.Empty, "City was not found. Either its deleted or edited");
                return View(model);
            }
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                TourName = model.TourName,
                CityId = model.CityId,
                InitialPrice = model.Price,
                From = model.From,
                Till = model.Till,
                Description = model.Description,
                Capacity = model.Capacity,
                IsAvailable = model.IsAvailable
            };
            var tourServices = new List<TourService>();
            if (model.ServicesId.Any())
            {
                foreach (var serviceId in model.ServicesId)
                {
                    Service service = await _context.Services.FindAsync(serviceId);
                    if (service == null)
                    {
                        continue;
                    }

                    TourService ts = new TourService()
                    {
                        TourId = tour.Id,
                        ServiceId = service.Id,
                    };
                    tourServices.Add(ts);

                }
            }
            tour.Services = tourServices;
            var tourImages = new List<TourImage>();
            foreach (var img in model.Images)
            {
                var imgLocation = await _imageHandler.GetLocationOfUploadedImage(img, ImageOwners.TourImage);
                Image newImg = new Image {ImageUrl = imgLocation, Id = Guid.NewGuid()};
                TourImage tm = new TourImage()
                {
                    TourId = tour.Id,
                    Image = newImg,
                };
                tourImages.Add(tm);
            }
            tour.TourImages = tourImages;

            await _context.Tours.AddAsync(tour);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var tourImage in tourImages)
            {
                _imageHandler.RemoveImage(ImageOwners.TourImage, tourImage.Image.ImageUrl);
            }

            ModelState.AddModelError(string.Empty, "Something went wrong");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tour = await _context.Tours.Include(e => e.TourRegistrations).ThenInclude(e => e.Client)
                .Include(e => e.Services).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (tour == null)
            {
                ViewData["Message"] = "Tour was not found";
                return View("NotFound");
            }

            ViewData["Services"] = new MultiSelectList(await _context.Services.ToListAsync(), nameof(Service.Id), nameof(Service.Name), tour.Services.Select(e => e.ServiceId).ToList());
            ViewData["Cities"] = new SelectList(await _context.Cities.ToListAsync(), nameof(City.Id), nameof(City.Name), tour.CityId);

            var model = new EditTourVm()
            {
                TourId = tour.Id,
                TourName = tour.TourName,
                From = tour.From,
                Till = tour.Till,
                IsAvailable = tour.IsAvailable,
                CityId = tour.CityId,
                ServicesId = tour.Services.Select(e => e.ServiceId).ToList(),
                Capacity = tour.Capacity,
                Price = tour.InitialPrice,
                Description = tour.Description,
                Registrations = tour.TourRegistrations.ToList(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTourVm model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Services"] = new MultiSelectList(await _context.Services.ToListAsync(), nameof(Service.Id), nameof(Service.Name), model.ServicesId);
                ViewData["Cities"] = new SelectList(await _context.Cities.ToListAsync(), nameof(City.Id), nameof(City.Name), model.CityId);
                return View(model);
            }
            if (!await _context.Cities.AnyAsync(e => e.Id == model.CityId))
            {
                ModelState.AddModelError(string.Empty, "City was not found, either it is deleted or is being edited.");
                return View(model);
            }
            var tour = await _context.Tours.Include(e => e.Services).Include(e => e.TourImages).ThenInclude(e => e.Image).AsTracking()
                .FirstOrDefaultAsync(e => e.Id == model.TourId);
            _context.Entry(tour).State = EntityState.Modified;
            _context.TourServices.RemoveRange(tour.Services);
            List<TourService> tourServices = new List<TourService>();
            foreach (var serviceId in model.ServicesId)
            {
                Service service = await _context.Services.FindAsync(serviceId);
                if (service == null)
                {
                    continue;
                }

                TourService ts = new TourService()
                {
                    TourId = tour.Id,
                    ServiceId = service.Id,
                };
                tourServices.Add(ts);

            }
            if (tourServices.Any())
            {
                await _context.TourServices.AddRangeAsync(tourServices);
            }

            if (model.Images.Any())
            {
                foreach (var tourImg in tour.TourImages)
                {
                    _imageHandler.RemoveImage(ImageOwners.TourImage, tourImg.Image.ImageUrl);
                }

                if (tour.TourImages.Any())
                {
                    _context.TourImages.RemoveRange(tour.TourImages);
                }
                List<TourImage> tourImages = new List<TourImage>();
                foreach (var img in model.Images)
                {
                    var imgLocation = await _imageHandler.GetLocationOfUploadedImage(img, ImageOwners.TourImage);
                    Image newImg = new Image { ImageUrl = imgLocation, Id = Guid.NewGuid() };
                    TourImage tm = new TourImage()
                    {
                        TourId = tour.Id,
                        Image = newImg,
                    };
                    tourImages.Add(tm);
                }

                await _context.TourImages.AddRangeAsync(tourImages);

            }
            
            tour.From = model.From;
            tour.Till = model.Till;
            tour.Description = model.Description;
            tour.TourName = model.TourName;
            tour.Capacity = model.Capacity;
            tour.IsAvailable = model.IsAvailable;
            tour.CityId = model.CityId;
            tour.InitialPrice = model.Price;
            _context.Tours.Update(tour);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return RedirectToAction("Index", "Tour", new {Area = "Panel"});
            }

            ModelState.AddModelError(string.Empty, "Something went wrong!!");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var tour = await _context.Tours.Include(e => e.City).Include(e=> e.TourRegistrations).FirstOrDefaultAsync(e => e.Id == id.Value);
            if (tour != null) return View(tour);

            ViewData["Message"] = "Tour was not found";
            return View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tour = await _context.Tours.Include(e => e.TourImages).ThenInclude(e => e.Image).SingleOrDefaultAsync(e => e.Id == id);
            
            if (tour == null)
            {
                ViewData["Message"] = "Tour was not found. Either it has been deleted or currently is being edited";
                return View("NotFound");
            }

            foreach (var tourTourImage in tour.TourImages)
            {
                _imageHandler.RemoveImage(ImageOwners.TourImage, tourTourImage.Image.ImageUrl);
            }

            _context.Tours.Remove(tour);
            var saveChangesAsync = await _context.SaveChangesAsync();
            if (saveChangesAsync >= 1) return RedirectToAction("Index");
            ViewData["Message"] = "Something went wrong";
            return View("NotFound");
        }


        [HttpGet]
        public async Task<IActionResult> TourDetails(Guid id)
        {
            var model = await _context.Tours.Include(e => e.TourRegistrations).ThenInclude(e => e.Client)
                .Include(e => e.TourRegistrations).ThenInclude(e => e.Payment).Include(e => e.Services).ThenInclude(e => e.Service).Include(e => e.TourRegistrations).ThenInclude(e => e.Services).ThenInclude(e => e.Service).FirstOrDefaultAsync(e => e.Id == id);
            return View(model);
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckTourNameIsUnique(string tourName)
        {
            var tourNameExists = await _context.Tours.AnyAsync(e => e.TourName == tourName);
            return !tourNameExists ? Json(true) : Json("Tour name is already taken.");
        }
    }
}
