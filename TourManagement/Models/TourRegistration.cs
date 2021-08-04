using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.Models
{
    public class TourRegistration
    {
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
        public Payment Payment { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public ICollection<RegistrationService> Services { get; set; }

    }
}
