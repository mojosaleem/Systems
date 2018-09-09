using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface ICash
    {
        IEnumerable<Cash> GetCashes{ get; }
        Cash this[int Id] { get; }
        Task AddCashAsync(Cash cash);
        Task<bool> UpdateCash(int id, Cash cash);
        Task<bool> DeleteCash(int id);
    }
}
