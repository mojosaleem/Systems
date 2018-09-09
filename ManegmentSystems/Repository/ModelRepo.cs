using ManegmentSystems.Data.Models;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.ViewModel
{
    public class ModelRepo : IModel
    {

        public Dictionary<int, Model> Persons;
        CarMangerContext _context;
        List<Model> lss;
        public ModelRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, Model>();
            lss = _context.Model.ToList<Model>();

            lss.ForEach(async r => await AddModel(r));
        }

        public Model this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IEnumerable<Model> GetModels => Persons.Values;


        public async Task<Model> AddModel(Model model)
        {


            Persons[model.Id] = model;
            if (!_context.SalePerson.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.Model.Add(model);

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }

            return model; ;
        }



        public async Task<bool> DeleteModel(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.Model.Remove(_context.Model.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }



        public async Task<bool> UpdateModel(int id, Model model)
        {
            _context.Entry(model).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SalePerson.Any(e => e.Id == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }


    }
}

