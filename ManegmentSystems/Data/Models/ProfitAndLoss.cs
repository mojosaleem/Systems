using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class ProfitAndLoss
    {
        public decimal Profit { get; set; }
        public decimal Loss { get; set; }
        public int SellRecordsId { get; set; }
        public int BuyRecordsId { get; set; }

        public BuyRecords BuyRecords { get; set; }
        public SellRecords SellRecords { get; set; }
    }
}
