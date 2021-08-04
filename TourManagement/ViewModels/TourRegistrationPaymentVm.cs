using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourManagement.ViewModels
{
    public class TourRegistrationPaymentVm
    {
        public Guid ClientId { get; set; }
        public Guid TourId { get; set; }
        public List<Guid> ServicesId { get; set; }
        public Dictionary<string, decimal> Dictionary { get; set; } = new Dictionary<string, decimal>();
        public decimal Total { get; set; }
    }
}
