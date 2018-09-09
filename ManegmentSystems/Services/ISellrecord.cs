using ManegmentSystems.Data.Models;
using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.Services
{
    public interface ISellrecord
    {
        IQueryable<SellRecords> GetSellRecords { get; }
        SellRecords this[int Id] { get; }
        Task<int> AddsellRecords(SellRecords sellRecords);
        Task<bool> UpdatesellRecord(int id,SellRecords sellRecords);
        Task<bool> DeleteSellRecords(int id);
    }
}
