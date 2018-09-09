using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.Domain_object
{
    public class Search
    {
        public decimal PriceOutcome { get; set; }
        public string  ManufactureName { get; set; }
        public int modelID { get; set; }
        public int ManufactureID { get; set; }
        public string  ModelName { get; set; }
        public int CardID { get; set; }
        public string SallerName { get; set; }
        public string SallerID { get; set; }
        public bool IsSold { get; set; }
    }
}
