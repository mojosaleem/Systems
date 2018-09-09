using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class Income
    {
        public Income()
        {
            Cash = new HashSet<Cash>();
            Check = new HashSet<Check>();
            SellRecords = new HashSet<SellRecords>();
        }

        public decimal Price { get; set; }
        public int Id { get; set; }

        public ICollection<Cash> Cash { get; set; }
        public ICollection<Check> Check { get; set; }
        public ICollection<SellRecords> SellRecords { get; set; }
    }
}
