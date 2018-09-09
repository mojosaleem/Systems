using System;
using System.Collections.Generic;

namespace ManegmentSystems.Data.Models
{
    public partial class Model
    {
        public Model()
        {
            Car = new HashSet<Car>();
            InverseModelNavigation = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufactureId { get; set; }
        public int? ModelId { get; set; }

        public Manufacture Manufacture { get; set; }
        public Model ModelNavigation { get; set; }
        public ICollection<Car> Car { get; set; }
        public ICollection<Model> InverseModelNavigation { get; set; }
    }
}
