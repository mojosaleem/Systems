using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface IManufacture
    {
        IQueryable<Manufacture> GetManufactures { get; }
        Manufacture this[int Id] { get; }
        void AddManufacture(Manufacture manufacture);
        Task<bool> UpdateManufacture(int id,Manufacture manufacture);
        Task<bool> DeleteManufacture(int id);
    }
}
