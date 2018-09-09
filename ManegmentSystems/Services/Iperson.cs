using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Models;
using Microsoft.AspNetCore.Mvc;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface Iperson
    {
        IQueryable<SalePerson> GetSalePerson { get; }
        SalePerson this[int Id] { get; }
        Task<int> AddSalePerson(SalePerson model);
        Task<bool> UpdateSalePerson(int id,SalePerson model);
        Task<bool> DeleteSalePerson(int id);



    }
}
