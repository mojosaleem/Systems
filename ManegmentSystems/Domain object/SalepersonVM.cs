using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.Domain_object
{
    public class SalepersonVM
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public IFormFile IdPhoto { get; set; }
    }
}
