using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSYSModels
{
    [Serializable]
    public class Sale
    {
        public int SaleId { get; set; }
        public Man ManSale { get; set; }
        public Car CarBrnad { get; set; }
        public DateTime Time { get; set; }
        public int Count { get; set; }
    }
}
