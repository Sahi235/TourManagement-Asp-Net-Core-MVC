using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using TourManagement.Models;

namespace TourManagement.ViewModels
{
    public class RegisterTourVm
    {
        public Tour Tour { get; set; }
        public Guid TourId { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Full Name")]
        public string ClientName { get; set; }
        [Required]
        [MaxLength(1080)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string ClientEmail { get; set; }
        [Required]
        [MaxLength(255)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string ClientPhoneNumber { get; set; }
        public List<Guid> ServicesId { get; set; }

        public IFormFile PassportPic { get; set; }
    }
}
