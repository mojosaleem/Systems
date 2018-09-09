using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
   public  interface ICapitalShare
    {
        IQueryable<CapitalShare> GetCapitalShares { get; }
        CapitalShare this[int Id] { get; }
  
    }
}
