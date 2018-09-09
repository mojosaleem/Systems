using ManegmentSystems.Data.Models;
using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.Services
{
    public interface IAfterBuyExpncess
    {
        IQueryable<AfterBuyExpencess> GetAfterBuyExpncesses { get; }
        AfterBuyExpencess this[int Id] { get; }
        Task AddAfterBuyExpncessAsync(AfterBuyExpencess afterBuyExpncess);
        void UpdateAfterBuyExpncess(AfterBuyExpencess afterBuyExpncess);
        void DeleteAfterBuyExpncessr(int id);
    }
}
