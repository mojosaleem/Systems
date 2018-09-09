using ManegmentSystems.Data.Models;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.ViewModel
{
    public class BuyRepos : IBuy
    {
        public Dictionary<int, Buy> Persons;
        CarMangerContext _context;
        List<Buy> lss;
        public BuyRepos()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, Buy>();
            lss = _context.Buy.OrderBy(i => i.Id).Include(c => c.BuyRecords).Include(a => a.Car).Include(b => b.BuyRecords).Include(d => d.Customer).Select(y => new Buy
            {
                Id = y.Id,
                Customer = y.Customer,
                BuyRecords = y.BuyRecords,
                Car = y.Car,
                CarId = y.CarId,
                CustomerId = y.CustomerId,
                Date = y.Date
            }).ToList();
            lss.ForEach(async r => await AddBuy(r));
        }

        public Buy this[int Id] => Persons.ContainsKey(Id)? Persons[Id] : null;

        public IEnumerable<Buy> GetBuys => Persons.Values;

        public async Task<int> AddBuy(Buy model)
        {
            if (!_context.Buy.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.Buy.Add(model);
                    model.Date = new DateTime().Date.Date;
                    await _context.SaveChangesAsync();
                }catch(Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }
            Persons[model.Id] = model;
            return model.Id;
        }

        public async Task<bool> DeleteBuy(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.Buy.Remove(_context.Buy.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> UpdateBuy(int id,Buy model)
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
