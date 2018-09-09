using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class AfterSellExpncess
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public int? RecordId { get; set; }

        public SellRecords Record { get; set; }
    }
}
