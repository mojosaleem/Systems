using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface ICustomer
    {
        IQueryable<Customer> GetCustomers { get; }
         Customer this[int Id] { get; }
        Task<int> AddCustomer(Customer model);
        Task<bool> UpdateCustomer(int id, Customer model);
        Task<bool> DeleteCustomer(int id);
    }
}
