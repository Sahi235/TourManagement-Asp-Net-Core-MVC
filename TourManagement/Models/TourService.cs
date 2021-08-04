using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.Models
{
    public class TourService
    {
        public Guid TourId { get; set; }
        public Guid ServiceId { get; set; }
        public Tour Tour { get; set; }
        public Service Service { get; set; }
    }
}
