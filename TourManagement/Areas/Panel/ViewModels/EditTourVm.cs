using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using TourManagement.Models;

namespace TourManagement.Areas.Panel.ViewModels
{
    public class EditTourVm
    {
        public Guid TourId { get; set; }
        public int Capacity { get; set; }
        public string TourName { get; set; }
        public List<TourRegistration> Registrations { get; set; } = new List<TourRegistration>();
        public DateTime From { get; set; }
        public DateTime Till { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }
        public Guid CityId { get; set; }
        public List<Guid> ServicesId { get; set; }
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();

    }
}
