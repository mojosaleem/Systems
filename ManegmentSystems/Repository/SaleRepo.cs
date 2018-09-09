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
    public class SaleRepo :ISale
    {
        public Dictionary<int, Sale> Persons;
        CarMangerContext _context;
        List<Sale> lss;
        public SaleRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, Sale>();
            lss = _context.Sale.OrderBy(i => i.Id).Include(c => c.SellRecords).Include(a => a.Car).Include(d => d.Customer).Select(y => new Sale
            {
               Car=y.Car,
               SellRecords=y.SellRecords,
               CarId=y.CarId,
               Commission=y.Commission,
               Customer=y.Customer,
               CustomerId=y.CustomerId,
               Date=y.Date,
               Id=y.Id
            }).ToList();
            lss.ForEach(async r => await Addsale(r));
        }

        public Sale this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IEnumerable<Sale> GetSales => Persons.Values;

        IQueryable<Sale> ISale.GetSales => throw new NotImplementedException();

        public async Task<int> Addsale(Sale model)
        {
            if (!_context.Sale.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.Sale.Add(model);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }
            Persons[model.Id] = model;
            return model.Id;
        }

       

        public async Task<bool> DeleteSale(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.Sale.Remove(_context.Sale.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> UpdateSale(int id, Sale model)
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
