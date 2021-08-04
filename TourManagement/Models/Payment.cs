using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid TourRegistrationId { get; set; }
        public TourRegistration TourRegistration { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaymentAmount { get; set; }

    }
}
