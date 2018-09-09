using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class Car
    {
        public Car()
        {
            Buy = new HashSet<Buy>();
            Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool Insurance { get; set; }
        public string Owener { get; set; }
        public string CarId { get; set; }
        public string MoreDetails { get; set; }
        public bool Sold { get; set; }

        public Model Model { get; set; }
        public ICollection<Buy> Buy { get; set; }
        public ICollection<Sale> Sale { get; set; }
    }
}
