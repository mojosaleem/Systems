using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Domain_object
{
    public class BUYACARINFO
    {
        public int caridd { get; set; }
        public string SaleName { get; set; }
        public string SaleAdress { get; set; }
        public string IDNumber { get; set; }
        public string SalePhone { get; set; }
        public string IdPhoto { get; set; }
        public DateTime DateOfBuy { get; set; }
        public decimal PriceOutcome { get; set; }
        public IEnumerable<Cash> cashes { get; set; }
        public IEnumerable<Check> checks { get; set; }
        public string ManufactureName { get; set; }

        public string ModelName { get; set; }
        public bool? Insurance { get; set; }
        public string CarOwener { get; set; }
        public string CarID { get; set; }
        public string moreDetails { get; set; }

    }
}
