using ManegmentSystems.Data.Models;
using ManegmentSystems.Domain_object;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using ManegmentSystems.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManegmentSystems.Repository
{
    public class carInfo : IcarInfo
    {
        public Dictionary<int, BUYACARINFO> Persons;
        CarMangerContext _context;
        List<BUYACARINFO> lss;
        public carInfo()
        {
            _context = new CarMangerContext();
            Persons = new Dictionary<int, BUYACARINFO>();
            lss = _context.BuyRecords.Include(a=>a.AfterBuyExpencess).Include(a=>a.Buy).Include(a=>a.Outcome).Include(a=>a.Partner).Select(a=>new BUYACARINFO() {
               CarOwener=a.Buy.Car.Owener,
               CarID=a.Buy.Car.CarId,
               cashes=a.Outcome.Cash,
               checks=a.Outcome.Check,
               DateOfBuy=a.Buy.Date,
               IdPhoto=a.Buy.Customer.IdPhoto,
               IDNumber=a.Buy.Customer.Idnumber,
               Insurance=a.Buy.Car.Insurance,
               ManufactureName=a.Buy.Car.Model.Manufacture.Name,
               ModelName=a.Buy.Car.Model.Name,
               moreDetails=a.Buy.Car.MoreDetails,
               PriceOutcome=a.Outcome.Price,
               SaleAdress=a.Buy.Customer.Adress,
               SaleName= a.Buy.Customer.Name,
               SalePhone= a.Buy.Customer.Phone,
               caridd=a.Buy.CarId



            }).ToList();
            lss.ForEach( r =>  AddBuyRecords(r));
        }
        public BUYACARINFO this[int Id] => Persons.ContainsKey(Id) ? Persons[Id] : null;

       

        private void AddBuyRecords(BUYACARINFO buyRecords)
        {
            Persons[buyRecords.caridd] = buyRecords;
          

           
        }

    }
}
