using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.ViewModel
{
    public class SalepersonRepos : Iperson
    {
        public Dictionary<int, SalePerson> Persons;
        CarMangerContext _context;
        List<SalePerson> lss;
        public SalepersonRepos()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, SalePerson>();
            lss = _context.SalePerson.ToList();
            lss.ForEach(async r => await AddSalePerson(r));
        }

        public SalePerson this[int Id] => Persons.ContainsKey(Id)? Persons[Id] : null;

        public IQueryable<SalePerson> GetSalePerson =>Persons.Values.AsQueryable();

        public async Task<int> AddSalePerson(SalePerson model)
        {

            
            if (!_context.SalePerson.Any(e => e.Id == model.Id))
            {
                try { 
                _context.SalePerson.Add(model);
                await _context.SaveChangesAsync();
                }catch(Exception ex)
                {
                    var x =ex.Message;
                }
            }
                         Persons[model.Id] = model;

            

            return model.Id;
        }

        public async Task<bool> DeleteSalePerson(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.SalePerson.Remove(_context.SalePerson.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> UpdateSalePerson(int id,SalePerson model)
        {
            _context.Entry(model).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SalePerson.Any(e=>e.Id==id))
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
