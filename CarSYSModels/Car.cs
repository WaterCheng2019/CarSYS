using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSYSModels
{
    [Serializable]
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public Brand CarBrand { get; set; }
        public string Picture { get; set; }
        public decimal OffcialPrice { get; set; }
        public int Click { get; set; }

    }
}
