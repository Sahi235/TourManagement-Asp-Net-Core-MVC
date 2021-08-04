using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.Models
{
    public class RegistrationService
    {
        public Guid RegistrationId { get; set; }
        public Guid ServiceId { get; set; }
        public TourRegistration TourRegistration { get; set; }
        public Service Service { get; set; }
    }
}
