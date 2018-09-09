using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    interface IProfit_and_loss
    {
        IEnumerable<ProfitAndLoss> GetCustomer { get; }
        ProfitAndLoss this[int Id] { get; }
        ProfitAndLoss AddProfitAndLoss(ProfitAndLoss profitAndLoss);
        ProfitAndLoss UpdateProfitAndLoss(ProfitAndLoss profitAndLoss);
        void DeleteProfitAndLoss(int id);
    }
}
