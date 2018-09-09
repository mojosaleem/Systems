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
    public class IncomeRepo : IIncome
    {
        public Dictionary<int, Income> Persons;
        CarMangerContext _context;
        List<Income> lss;
        public IncomeRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, Income>();
            lss = _context.Income.ToList();
            lss.ForEach(async r => await AddIncome(r));
        }

        public Income this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IQueryable<Income> GetIncomes => Persons.Values.AsQueryable();

        public async Task<int> AddIncome(Income model)
        {


            Persons[model.Id] = model;
            if (!_context.Income.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.Income.Add(model);

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }

            return model.Id;
        }

        public async Task<bool> DeleteIncome(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.Income.Remove(_context.Income.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> UpdateIncome(int id, Income model)
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
