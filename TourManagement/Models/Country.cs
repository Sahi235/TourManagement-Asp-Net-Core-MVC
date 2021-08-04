using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(2)]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

    }
}
