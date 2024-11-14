using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingSystem.Core.Models.Car
{
    public class CarQueryServiceModel
    {
        public int TotalCarCount { get; set; }
        public IEnumerable<CarServiceModel> Cars { get; set; } = new List<CarServiceModel>();
    }
}
