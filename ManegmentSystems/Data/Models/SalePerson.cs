using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class SalePerson
    {
        public SalePerson()
        {
            Buy = new HashSet<Buy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string IdPhoto { get; set; }
        public string Idnumber { get; set; }

        public ICollection<Buy> Buy { get; set; }
    }
}
