using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class Cash
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool Arrested { get; set; }
        public DateTime DateArrested { get; set; }
        public int? IncomeId { get; set; }
        public int? OutcomeId { get; set; }

        public Income Income { get; set; }
        public Outcome Outcome { get; set; }
    }
}
