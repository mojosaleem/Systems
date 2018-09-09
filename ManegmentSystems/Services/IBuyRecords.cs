using ManegmentSystems.Domain_object;
using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface IBuyRecords
    {
        IQueryable<BuyRecords> GetBuyRecords { get; }
        BuyRecords this[int Id] { get; }
        Task<BuyRecords> AddBuyRecords(BuyRecords buyRecords);
        Task<bool> UpdateBuyRecords(int id, BuyRecords buyRecords);
        Task<bool> DeleteBuyRecords(int id);
        IQueryable<Search> GetRecords(int price_from,int price_to);
    }
}
