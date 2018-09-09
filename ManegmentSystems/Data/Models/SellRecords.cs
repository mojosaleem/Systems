using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class SellRecords
    {
        public SellRecords()
        {
            AfterSellExpncess = new HashSet<AfterSellExpncess>();
            ProfitAndLoss = new HashSet<ProfitAndLoss>();
        }

        public int? SaleId { get; set; }
        public int? IncomeId { get; set; }
        public int? PartnerId { get; set; }
        public int Id { get; set; }

        public Income Income { get; set; }
        public Partner Partner { get; set; }
        public Sale Sale { get; set; }
        public ICollection<AfterSellExpncess> AfterSellExpncess { get; set; }
        public ICollection<ProfitAndLoss> ProfitAndLoss { get; set; }
    }
}
