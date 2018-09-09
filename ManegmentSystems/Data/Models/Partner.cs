using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class Partner
    {
        public Partner()
        {
            BuyRecords = new HashSet<BuyRecords>();
            SellRecords = new HashSet<SellRecords>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal OwenMoeny { get; set; }

        public ICollection<BuyRecords> BuyRecords { get; set; }
        public ICollection<SellRecords> SellRecords { get; set; }
    }
}
