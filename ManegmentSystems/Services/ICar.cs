using ManegmentSystems.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface ICar
    {
        IQueryable<Car> GetCars { get; }
        Car this[int Id] { get; }
        Task<int> AddCar(Car car);
        Task<bool> UpdateCarAsync(Car car);
        Task<bool> DeleteCar(int id);
    }
}
