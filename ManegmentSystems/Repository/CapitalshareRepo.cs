using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Repository
{
    public class CapitalshareRepo : ICapitalShare
    {
        public Dictionary<int, CapitalShare> Persons;
        CarMangerContext _context;
        List<CapitalShare> lss;
        public CapitalshareRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, CapitalShare>();
            lss = _context.CapitalShare.ToList();
            lss.ForEach(a => addcc(a));
        }

        

        CapitalShare ICapitalShare.this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;
  

        public IQueryable<CapitalShare> GetCapitalShares => Persons.Values.AsQueryable();

        private void addcc(CapitalShare dd)
        {
            Persons[dd.Id] = dd;
        }
      
        
    }
}
