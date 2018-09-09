using ManegmentSystems.Data.Models;
using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.Services
{
    public interface IBuy
    {
        IEnumerable<Buy> GetBuys { get; }
        Buy this[int Id] { get; }
        Task<int> AddBuy(Buy model);
        Task<bool> UpdateBuy(int id, Buy model);
        Task<bool> DeleteBuy(int id);

    }
}
