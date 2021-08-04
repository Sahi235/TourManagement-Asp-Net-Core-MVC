using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourManagement.Models
{
    public class Tour
    {
        public Guid Id { get; set; }
        [MaxLength(255)]
        [Required]
        [MinLength(3)]
        public string TourName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime From { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Till { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        public decimal InitialPrice { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string Description { get; set; }
        [Required]
        public int Capacity { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public ICollection<TourClient> TourClients { get; set; }
        public ICollection<TourImage> TourImages { get; set; }
        public ICollection<TourService> Services { get; set; }
        public ICollection<TourRegistration> TourRegistrations { get; set; }

    }
}
