using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.ViewModel
{
    public class CarRepo:ICar
    {
        public Dictionary<int, Car> Persons;
        CarMangerContext _context;
        IQueryable<Car> lss;
        public CarRepo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, Car>();
            lss = _context.Car.AsNoTracking().OrderBy(i => i.Id).Include(a => a.Model.Manufacture).Include(a=>a.Model).Include(b=>b.Buy).Include(e=>e.Sale).Select(y => new Car
            {
                Id = y.Id,
                Buy=y.Buy,
                Sale=y.Sale,
                CarId = y.CarId,
                Model=y.Model,                
                Insurance=y.Insurance,
                ModelId=y.ModelId,
                MoreDetails=y.MoreDetails,
                Owener=y.Owener,
                Sold=y.Sold
               
            });
            lss.ToList().ForEach(async r => await AddCar(r));
        }

        public Car this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

        public IQueryable<Car> GetCars => lss;

     

        public async Task<int> AddCar(Car model)
        {

            
            if (!_context.Car.Any(e => e.Id == model.Id))
            {
                try
                {
                    _context.Car.Add(model);

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            Persons[model.Id] = model;

            return model.Id;
        }

        public async Task<bool> DeleteCar(int id)
        {
            if (Persons.ContainsKey(id))
            {
                Persons.Remove(id);
                _context.Car.Remove(_context.Car.Find(id));
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

     

        public async Task<bool> UpdateCarAsync(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
