using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.ViewModel
{
    public class OutComeRepo:IOutcome
    {
        public Dictionary<int, Outcome> Persons;
        CarMangerContext _context;
        List<Outcome> lss;
        public OutComeRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, Outcome>();
            lss = _context.Outcome.ToList();
            lss.ForEach(async r => await AddOutcome(r));
        }

        public Outcome this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IEnumerable<Outcome> GetOutcomes => Persons.Values;

        public async Task<int> AddOutcome(Outcome model)
        {


            Persons[model.Id] = model;
            if (!_context.Outcome.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.Outcome.Add(model);
                    
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }

            return model.Id;
        }

        public async Task<bool> DeleteOutcome(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.Outcome.Remove(_context.Outcome.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> UpdateOutcome(int id, Outcome model)
        {
            _context.Entry(model).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SalePerson.Any(e => e.Id == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }

    
     }
}
