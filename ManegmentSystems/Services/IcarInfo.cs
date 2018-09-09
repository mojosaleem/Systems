using ManegmentSystems.Domain_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
   public  interface IcarInfo
    {
         BUYACARINFO this[int Id] { get; }
    }
}
