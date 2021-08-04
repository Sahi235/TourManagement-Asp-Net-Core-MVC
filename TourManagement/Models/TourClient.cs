using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.Models
{
    public class TourClient
    {
        public Guid TourId { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Tour Tour { get; set; }
    }
}
