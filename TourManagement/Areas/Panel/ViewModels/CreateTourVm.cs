using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TourManagement.Areas.Panel.ViewModels
{
    public class CreateTourVm
    {
        public CreateTourVm()
        {
            Images = new List<IFormFile>();
            ServicesId = new List<Guid>();
        }
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        [Remote(action: "CheckTourNameIsUnique", controller:"Tour", areaName:"Panel")]
        public string TourName { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime Till { get; set; }
        [Required]
        public Guid CityId { get; set; }
        public string Description { get; set; }
        public List<Guid> ServicesId { get; set; }
        [MinLength(1, ErrorMessage = "Image can not be empty, Please add at least one image")]
        public List<IFormFile> Images { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
