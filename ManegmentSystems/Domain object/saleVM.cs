using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.Domain_object
{
    public class saleVM
    {
        public decimal cashTaken { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerPhone { get; set; }
        public IFormFile CustomerIdPhoto { get; set; }
        public int carID { get; set; }
        public string ModelName { get; set; }
        public string  manufactureName { get; set; }
 
        public decimal PriceIncome { get; set; }
        public List<decimal> CashAmount { get; set; }
        public bool arrested { get; set; }

        public List<decimal> CheckAmount { get; set; }
        public List<DateTime> DueDate { get; set; }
        public List<string> CheckOwner { get; set; }
        [BindProperty]
        public IFormFileCollection CheckPhoto { get; set; }
    }
}
