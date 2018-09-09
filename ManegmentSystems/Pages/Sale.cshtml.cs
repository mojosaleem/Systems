using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Domain_object;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManegmentSystems.Data.Models;
using ManegmentSystems.Data;
using System.Security.Claims;

namespace ManegmentSystems.Pages
{
    public class SaleModel : PageModel
    {
        public int id;
        private readonly ICar car;
        private readonly IManufacture manufacture;
        private readonly Ifile _file;
        private readonly ISale _sale;
        private readonly ISellrecord sellrecord;
        private readonly IIncome income;
        private readonly ICash cash;
        private readonly ICheck check;
        private readonly ICustomer customer;

        public SaleModel( ICar car, IManufacture manufacture, Ifile file, ISale sale, ISellrecord sellrecord, IIncome income, ICash cash, ICheck check, ICustomer customer)
        {
           
            this.car = car;
            this.manufacture = manufacture;
            _file = file;
            _sale = sale;
            this.sellrecord = sellrecord;
            this.income = income;
            this.cash = cash;
            this.check = check;
            this.customer = customer;
        }

        [BindProperty]
        public saleVM cars { get;  set; }
        public IActionResult OnGet(int carid)
        {

            if (carid!=0)
            {

                id = carid;
                cars = new saleVM() {carID=id ,ModelName=car[id].Model.Name,manufactureName=manufacture[car[id].Model.ManufactureId].Name};
                
                return Page();
            }
            else
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
          int customerID=  await customer.AddCustomer(new Customer()
            {
                Adress = cars.CustomerAdress,
                IdPhoto = await Uplode(cars.CustomerIdPhoto, "Customers"),
                Name=cars.CustomerName,
                Phone=cars.CustomerPhone

            });
          int incomeID=  await income.AddIncome(new Income()
            {
                Price=cars.PriceIncome
            });
            if (cars.CheckAmount.Count > 0)
            {
                for (int i = 0; i < cars.CheckAmount.Count; i++)
                {
                    check.AddCheck(new Check()
                    {
                        Amount = cars.CheckAmount[i],
                        DueDate = cars.DueDate[i],
                        IncomeId = incomeID,
                        Name = cars.CheckOwner[i],
                        Photo = await Uplode(cars.CheckPhoto[i], "Check")
                    });
                }
            }
            await cash.AddCashAsync(new Cash()
            {
                Amount = cars.cashTaken,
                IncomeId = incomeID,
                Arrested = true
            });
          

            int saleID = await _sale.Addsale(new Sale() {
                CarId=cars.carID,
                Commission=0,
                CustomerId=customerID,
                Date =DateTime.Today,
                           });
            var x = car[cars.carID];
            x.Sold = true;
            await car.UpdateCarAsync(x);
            await sellrecord.AddsellRecords(new SellRecords()
            {IncomeId=incomeID,
            SaleId=saleID

            });
            callproc cc = new callproc();
            cc.updateCapitalShare(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            cc = null;

            return RedirectToAction("Index", "Home");
        }
        private async Task<string> Uplode(IFormFile file, string name)
        {


            return await _file.Upload_Image((FormFile)file, name);

        }

    }
}