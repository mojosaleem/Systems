using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface ISale
    {
        IQueryable<Sale> GetSales { get; }
        Sale this[int Id] { get; }
        Task<int> Addsale(Sale sale);
        Task<bool> UpdateSale(int id, Sale sale);
        Task<bool> DeleteSale(int id);
    }
}
