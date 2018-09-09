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
    public class ManufactureRepo : IManufacture
    {

        public Dictionary<int, Manufacture> Persons;
        CarMangerContext _context;
        List<Manufacture> lss;
        public ManufactureRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, Manufacture>();
            lss = _context.Manufacture.Include(c => c.Model).
                    Select(b => new Manufacture
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Model = b.Model.ToList()

                    }).ToList<Manufacture>();

            lss.ForEach( r =>  AddManufacture(r));
        }

        public Manufacture this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IQueryable<Manufacture> GetManufactures => Persons.Values.AsQueryable<Manufacture>();


        public void AddManufacture(Manufacture model)
        {


            Persons[model.Id] = model;
            if (!_context.Manufacture.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.Manufacture.Add(model);

                     _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }

            
        }



        public async Task<bool> DeleteManufacture(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.Manufacture.Remove(_context.Manufacture.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }



        public async Task<bool> UpdateManufacture(int id, Manufacture model)
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

