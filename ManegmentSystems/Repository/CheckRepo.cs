using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;
using ManegmentSystems.Data;

namespace ManegmentSystems.ViewModel
{
    public class CheckRepo : ICheck
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private callproc cc;
        public Dictionary<int, Check> Persons;
        CarMangerContext _context;
        List<Check> lss;
        public CheckRepo(IHostingEnvironment hostingEnvironment)
        {
            cc = new callproc();
            this._hostingEnvironment = hostingEnvironment;
            _context = new CarMangerContext();
            Persons = new Dictionary<int, Check>();
            lss = _context.Check.ToList();
            lss.ForEach( r =>  AddCheck(r));
        }

        public Check this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IEnumerable<Check> GetChecks => Persons.Values;

        public int AddCheck(Check model)
        {


          
            if (!_context.Check.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.Check.Add(model);

                     _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }
           Persons[model.Id] = model;
            return model.Id;
        //    cc.updateCapitalShare();
        }



        public async Task<bool> DeleteCheck(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.BuyRecords.Remove(_context.BuyRecords.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }



        public async Task<bool> UpdateCheck(int id, Check model)
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

