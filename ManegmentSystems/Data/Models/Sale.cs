using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public decimal Commission { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int CarId { get; set; }

        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public SellRecords SellRecords { get; set; }
    }
}
