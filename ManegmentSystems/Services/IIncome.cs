using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface IIncome
    {
        IQueryable<Income> GetIncomes { get; }
        Income this[int Id] { get; }
        Task<int> AddIncome(Income income);
        Task<bool> UpdateIncome(int id,Income income);
        Task<bool> DeleteIncome(int id);
    }
}
