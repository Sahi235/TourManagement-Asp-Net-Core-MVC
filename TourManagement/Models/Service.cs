using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string Name { get; set; }
        [Column(TypeName = "Decimal(18,2)")] public decimal Price { get; set; } = 0;
        public ICollection<TourService> Tours { get; set; }
        public ICollection<RegistrationService> Registrations { get; set; }

    }
}
