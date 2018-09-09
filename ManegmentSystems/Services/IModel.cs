using ManegmentSystems.Data.Models;
using ManegmentSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.Services
{
    public interface IModel
    {
        IEnumerable<Model> GetModels { get; }
        Model this[int Id] { get; }
        Task<Model> AddModel(Model model);
        Task<bool> UpdateModel(int id,Model model);
        Task<bool> DeleteModel(int id);
    }
}
