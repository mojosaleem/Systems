using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface IOutcome
    {
        IEnumerable<Outcome> GetOutcomes { get; }
        Outcome this[int Id] { get; }
        Task<int> AddOutcome(Outcome outcome);
        Task<bool> UpdateOutcome(int id,Outcome outcome);
        Task<bool> DeleteOutcome(int id);
    }
}
