using ManegmentSystems.Domain_object;
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
    public class BuyRecordRepo : IBuyRecords
    {

        public Dictionary<int, BuyRecords> Persons;
        CarMangerContext _context;
        List<BuyRecords> lss;
        public BuyRecordRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, BuyRecords>();
            lss = _context.BuyRecords.Include(a=>a.Buy).Include(a=>a.AfterBuyExpencess).ToList();
            lss.ForEach(async r => await AddBuyRecords(r));
        }

        public BuyRecords this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IQueryable<BuyRecords> GetBuyRecords => Persons.Values.AsQueryable();

        public async Task<BuyRecords> AddBuyRecords(BuyRecords model)
        {


            Persons[model.Id] = model;
            if (!_context.BuyRecords.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.BuyRecords.Add(model);

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }

            return model; ;
        }

        public  IQueryable<Search> GetRecords(int price_from,int price_to) {
          var x=  _context.BuyRecords.Include(a => a.Buy).Include(b=>b.Outcome).Where(f=>f.Outcome.Price>=price_from&&f.Outcome.Price<=price_to).Select(c=>new Search() {
              ManufactureName=c.Buy.Car.Model.Manufacture.Name,
              ManufactureID = c.Buy.Car.Model.Manufacture.Id,
              modelID = c.Buy.Car.ModelId,
              ModelName = c.Buy.Car.Model.Name,
              PriceOutcome=c.Outcome.Price,
              CardID=c.Buy.CarId,
              SallerID=c.Buy.Customer.Idnumber,
              SallerName=c.Buy.Customer.Name,
              IsSold=c.Buy.Car.Sold

          });
            return x;

    }
       

        public async Task<bool> DeleteBuyRecords(int id)
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

       

        public async Task<bool> UpdateBuyRecords(int id, BuyRecords model)
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

