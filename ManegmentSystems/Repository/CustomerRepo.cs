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
    public class CustomerRepo : ICustomer
    {
        public Dictionary<int, Customer> Persons;
        CarMangerContext _context;
        List<Customer> lss;
        public CustomerRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, Customer>();
            lss = _context.Customer.ToList();
            lss.ForEach(async r => await AddCustomer(r));
        }

        public Customer this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        

        public IQueryable<Customer> GetCustomers => Persons.Values.AsQueryable();

        public async Task<int> AddCustomer(Customer model)
        {


            if (!_context.Customer.Any(e => e.Id == model.Id))
            {

                _context.Customer.Add(model);
                await _context.SaveChangesAsync();
            }
            Persons[model.Id] = model;



            return model.Id;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.Customer.Remove(_context.Customer.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> UpdateCustomer(int id, Customer model)
        {
            _context.Entry(model).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customer.Any(e => e.Id == id))
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
