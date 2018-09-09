using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class CapitalShare
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string AspNetUsersId { get; set; }
        public DateTime DateAdd { get; set; }

        public AspNetUsers AspNetUsers { get; set; }
    }
}
