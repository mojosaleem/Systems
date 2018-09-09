using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class Buy
    {
        public Buy()
        {
            BuyRecords = new HashSet<BuyRecords>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int CarId { get; set; }
        public bool IsSold { get; set; }

        public Car Car { get; set; }
        public SalePerson Customer { get; set; }
        public ICollection<BuyRecords> BuyRecords { get; set; }
    }
}
