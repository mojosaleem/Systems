using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class Manufacture
    {
        public Manufacture()
        {
            Model = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Model> Model { get; set; }
    }
}
