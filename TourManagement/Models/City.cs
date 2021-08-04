using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.Models
{
    public class City
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Tour> Tours { get; set; }

    }
}
