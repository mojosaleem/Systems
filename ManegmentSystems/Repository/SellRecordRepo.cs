using ManegmentSystems.Domain_object;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Repository
{
    public class SellRecordRepo :ISellrecord
    {

        public Dictionary<int, SellRecords> Persons;
        CarMangerContext _context;
        List<SellRecords> lss;
        public SellRecordRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, SellRecords>();
            lss = _context.SellRecords.Include(a=>a.AfterSellExpncess).Include(a=>a.Sale).ToList();
            lss.ForEach(async r => await AddsellRecords(r));
        }

        public SellRecords this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IQueryable<SellRecords> GetSellRecords => Persons.Values.AsQueryable();

        public async Task<int> AddsellRecords(SellRecords model)
        {


            Persons[model.Id] = model;
            if (!_context.SellRecords.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.SellRecords.Add(model);

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Big Erro ");
                }
            }

            return model.Id ;
        }

        public IQueryable<Search> GetRecords(int price_from, int price_to)
        {
            var x = _context.SellRecords.Include(a=>a.Sale).Include(a=>a.Income).Select(c => new Search()
            {
                ManufactureName = c.Sale.Car.Model.Manufacture.Name,
                ManufactureID = c.Sale.Car.Model.Manufacture.Id,
                modelID = c.Sale.Car.ModelId,
                ModelName = c.Sale.Car.Model.Name,
                PriceOutcome = c.Income.Price,
                CardID = c.Sale.CarId

            });
            return x;

        }


        public async Task<bool> DeleteSellRecords(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.SellRecords.Remove(_context.SellRecords.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }


        public async Task<bool> UpdatesellRecord(int id, SellRecords model)
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
