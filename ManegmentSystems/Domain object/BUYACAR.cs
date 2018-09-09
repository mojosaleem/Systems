using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.ViewModel
{
    public class BUYACAR
    {
        public string SaleName { get; set; }
        public string SaleAdress { get; set; }
        public string IDNumber { get; set; }
        public string SalePhone { get; set; }
        public IFormFile IdPhoto { get; set; }
        public DateTime DateOfBuy { get; set; }
        public decimal PriceOutcome { get; set; }
        public List<decimal> CashAmount { get; set; }

        public List<decimal> CheckAmount { get; set; }
        public List<DateTime> DueDate { get; set; }
        public List<string> CheckOwner { get; set; }

        public IFormFileCollection Photo { get; set; }
        
        public int ManufactureID { get; set; }
        
        public int ModelId { get; set; }
        public bool ? Insurance { get; set; }
        public string CarOwener { get; set; }
        public string CarID { get; set; }
        public string moreDetails { get; set; }






    }
}
