using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Name length can not exceed 255 letter")]
        public string Name { get; set; }
        [Required]
        [MinLength(1030)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        public string PassportPhoto { get; set; }

        public ICollection<TourClient> Tours { get; set; }

    }
}
