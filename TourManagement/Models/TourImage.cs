using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.Models
{
    public class TourImage
    {
        public Guid TourId { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public Tour Tour { get; set; }
    }
}
