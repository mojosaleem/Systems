using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class Outcome
    {
        public Outcome()
        {
            BuyRecords = new HashSet<BuyRecords>();
            Cash = new HashSet<Cash>();
            Check = new HashSet<Check>();
        }

        public decimal Price { get; set; }
        public int Id { get; set; }

        public ICollection<BuyRecords> BuyRecords { get; set; }
        public ICollection<Cash> Cash { get; set; }
        public ICollection<Check> Check { get; set; }
    }
}
