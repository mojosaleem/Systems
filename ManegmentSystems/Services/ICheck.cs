using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface ICheck
    {
        IEnumerable<Check> GetChecks { get; }
        Check this[int Id] { get; }
        int AddCheck(Check check);
        Task<bool> UpdateCheck(int id, Check Check);
        Task<bool> DeleteCheck(int id);
    }
}
