using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class BuyRecords
    {
        public BuyRecords()
        {
            AfterBuyExpencess = new HashSet<AfterBuyExpencess>();
            ProfitAndLoss = new HashSet<ProfitAndLoss>();
        }

        public int OutcomeId { get; set; }
        public int BuyId { get; set; }
        public int? PartnerId { get; set; }
        public int Id { get; set; }

        public Buy Buy { get; set; }
        public Outcome Outcome { get; set; }
        public Partner Partner { get; set; }
        public ICollection<AfterBuyExpencess> AfterBuyExpencess { get; set; }
        public ICollection<ProfitAndLoss> ProfitAndLoss { get; set; }
    }
}
