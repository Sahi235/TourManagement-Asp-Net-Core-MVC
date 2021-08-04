using System.Collections.Generic;
using TourManagement.Models;

namespace TourManagement.ViewModels
{
    public class HomeDomesticVm
    {
        public HomeDomesticVm()
        {
            Cities = new List<City>();
            Tours = new List<Tour>();
        }
        public List<City> Cities { get; set; }
        public List<Tour> Tours { get; set; }
    }
}
