using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TourManagement.Constants;
using TourManagement.Database;
using TourManagement.ImageServices;
using TourManagement.Models;
using TourManagement.ViewModels;

namespace TourManagement.Controllers
{
    [AllowAnonymous]
    public class TourRegistrationController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IImageHandler _imageHandler;

        public TourRegistrationController(DatabaseContext context,
                                          IImageHandler imageHandler)
        {
            _context = context;
            _imageHandler = imageHandler;
        }

        [HttpGet]
        public async Task<IActionResult> TourRegister(Guid tourId)
        {
            var tour = await _context.Tours
                .Include(e => e.TourRegistrations)
                .Include(e => e.City)
                .ThenInclude(e => e.Country)
                .Include(e => e.Services)
                .ThenInclude(e => e.Service)
                .Include(e => e.TourImages)
                .ThenInclude(e => e.Image)
                .FirstOrDefaultAsync(e => e.Id == tourId);
            if (tour == null)
            {
                ViewData["Message"] = "Tour was not found either it is deleted or it is being edited";
                return View("NotFound");
            }
            ViewData["Services"] = new MultiSelectList(tour.Services.Select(e => e.Service).ToList(), nameof(Service.Id), nameof(Service.Name));
            var model = new RegisterTourVm { ServicesId = new List<Guid>() };
            model.Tour = model.Tour;
            model.TourId = tour.Id;
            if (tour.Capacity > tour.TourRegistrations.Count) return View(model);
            ViewData["Message"] = "Tour that you were looking for has already reached it`s max capacity";
            return View("NotFound");
        }

        [HttpPost]
        public async Task<IActionResult> TourRegister(RegisterTourVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client = await _context.Clients.FirstOrDefaultAsync(e => e.Name == model.ClientName);
            if (client != null)
            {
                var pVm = new TourRegistrationPaymentVm()
                {
                    ClientId = client.Id,
                    TourId = model.TourId,
                    ServicesId = model.ServicesId
                };
                return RedirectToAction(nameof(TourRegistrationPayment), pVm);
            }

            Client newClient = new Client()
            {
                Id = Guid.NewGuid(),
                Name = model.ClientName,
                Email = model.ClientEmail,
                PhoneNumber = model.ClientPhoneNumber,
            };
            var imageUploadResult =
                await _imageHandler.GetLocationOfUploadedImage(model.PassportPic, ImageOwners.ClientImage);
            newClient.PassportPhoto = imageUploadResult;
            await _context.Clients.AddAsync(newClient);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                ViewData["Message"] = "Something went wrong";
                return View("NotFound");
            }

            var addedClient = await _context.Clients.FirstOrDefaultAsync(e => e.Name == model.ClientName);
            var newVm = new TourRegistrationPaymentVm()
            {
                ClientId = newClient.Id,
                TourId = model.TourId,
                ServicesId = model.ServicesId,
            };
            return RedirectToAction(nameof(TourRegistrationPayment), newVm);
        }

        [HttpGet]
        public async Task<IActionResult> TourRegistrationPayment(TourRegistrationPaymentVm model)
        {
            var tour = await _context.Tours
                .Include(e => e.TourRegistrations)
                .Include(e => e.City)
                .ThenInclude(e => e.Country)
                .Include(e => e.Services)
                .ThenInclude(e => e.Service)
                .Include(e => e.TourImages)
                .ThenInclude(e => e.Image)
                .FirstOrDefaultAsync(e => e.Id == model.TourId);
            Dictionary<string, decimal> prices = new Dictionary<string, decimal>();
            prices["Tour Price"] = tour.InitialPrice;
            decimal total = tour.InitialPrice;
            foreach (var serId in model.ServicesId)
            {
                var service = await _context.Services.FindAsync(serId);
                prices[service.Name] = service.Price;
                total += service.Price;
            }

            prices["Total"] = total;
            model.Dictionary = prices;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> TourRegistrationPaymentConfirmation(TourRegistrationPaymentVm model)
        {
            var tour = await _context.Tours.FindAsync(model.TourId);
            var client = await _context.Clients.FindAsync(model.ClientId);

            var tourRegistration = new TourRegistration()
            {
                Id = Guid.NewGuid(),
                ClientId = client.Id,
                TourId = tour.Id,
                Payment = new Payment()
                {
                    Id = Guid.NewGuid(),
                    PaymentAmount = model.Total,
                }
            };

            var registrationServices = model.ServicesId.Select(serId => new RegistrationService() {ServiceId = serId, RegistrationId = tourRegistration.Id,}).ToList();

            await _context.AddRangeAsync(registrationServices);
            await _context.AddAsync(tourRegistration);
            var result = await _context.SaveChangesAsync();
            if (result <= 1)
            {
                ViewData["Message"] = "Something went wrong";
                return View("NotFound");
            }
            return RedirectToAction(nameof(PaymentConfirmation));
        }

        [HttpGet]
        public IActionResult PaymentConfirmation()
        {
            return View();
        }

    }
}
