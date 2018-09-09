using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;
using ManegmentSystems.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Web;


namespace ManegmentSystems.ViewModel
{
    public class CashRepo: ICash
    {

        public Dictionary<int, Cash> Persons;
        CarMangerContext _context;
        List<Cash> lss;
        private readonly UserManager<IdentityUser> _userManager;

        private callproc cc; public System.Security.Principal.IPrincipal User { get; set; }
        public CashRepo(UserManager<IdentityUser> userManager)
        {cc= new callproc();
            _userManager = userManager;
            _context = new CarMangerContext();
            Persons = new Dictionary<int, Cash>();
            lss = _context.Cash.ToList();
            lss.ForEach(async r => await AddCashAsync(r));
            

        }

        public Cash this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IEnumerable<Cash> GetCashes => Persons.Values;


        public async Task  AddCashAsync(Cash model)
        {



            if (!_context.Cash.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.Cash.Add(model);

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }


            
            Persons[model.Id] = model;

        }

      

        public async Task<bool> DeleteCash(int id)
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

       

        public async Task<bool> UpdateCash(int id, Cash model)
        {
            if (id != model.Id)
            {
                return false;
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }


            

        }
        private bool CashExists(int id)
        {
            return _context.Cash.Any(e => e.Id == id);
        }

      
    }
}

