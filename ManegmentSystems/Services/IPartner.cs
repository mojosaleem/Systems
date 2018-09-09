using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    interface IPartner
    {
        IEnumerable<Partner> GetPartners { get; }
        Partner this[int Id] { get; }
        Partner AddPartner(Partner partner);
        Partner UpdatePartner(Partner partner);
        void DeletePartner(int id);
    }
}
