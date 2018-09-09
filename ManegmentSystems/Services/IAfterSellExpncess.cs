using ManegmentSystems.Data.Models;
using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.Services
{
    public interface IAfterSellExpncess
    {
        IQueryable<AfterSellExpncess> GetallSellExpncesses { get; }
        AfterSellExpncess this[int Id] { get; }
        Task AddAfterSellExpncess(AfterSellExpncess afterSellExpncess);
        void UpdateAfterSellExpncess(AfterSellExpncess afterSellExpncess);
        void DeleteAfterSellExpncessr(int id);
    }
}
