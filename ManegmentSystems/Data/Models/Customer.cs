using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string IdPhoto { get; set; }

        public ICollection<Sale> Sale { get; set; }
    }
}
