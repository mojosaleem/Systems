using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using ManegmentSystems.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;
using Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using ManegmentSystems.Controllers;
using ManegmentSystems.Data.Models;
using ManegmentSystems.Data;
using System.Security.Claims;

namespace ManegmentSystems.Pages
{
    public class buyAcarModel : PageModel
    {
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IManufacture _manufacture;
        private readonly IOutcome _outcome;
        private readonly ICar _car;
        private readonly IBuy _buy;
        private readonly ICash _cash;
        private readonly ICheck _check;
        private readonly IBuyRecords _buyrecord;
        private readonly Iperson _saleperson;
        private readonly ICheck _incomes;

        private readonly Ifile _file;
        public IQueryable<cc> checks { get; set; }
        [BindProperty]
        public BUYACAR bUYACAR { get; set; }
        [BindProperty]
        


        public List<Check> js { get; set; }

        public buyAcarModel(IHostingEnvironment hostingEnv, ICheck incomes, IManufacture manufacture, IOutcome outcome, ICar car, IBuy buy, ICash cash, ICheck check, IBuyRecords buyrecord, Iperson saleperson, Ifile file)
        {
            _incomes = incomes;
            _hostingEnv = hostingEnv;
            _manufacture = manufacture;
            _outcome = outcome;
            _car = car;
            _buy = buy;
            _cash = cash;
            _check = check;
            _buyrecord = buyrecord;
            _saleperson = saleperson;
            _file = file;
        }

        public void OnGet()
        {

            checks = _incomes.GetChecks.Where(a => a.OutcomeId == null).Select(a => new cc() {
                Id = a.Id,
                Amount = a.Amount,
                DueDate = a.DueDate.ToShortDateString(),
                Name = a.Name,
                files = a.Photo
            }).AsQueryable();

            string json = JsonConvert.SerializeObject(checks);
            System.IO.File.WriteAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json", string.Empty);

            System.IO.File.WriteAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json", json);






        }

        public IActionResult OnPostBuyForm(List<string> x)
        {

            List<cc> cdd = new List<cc>() ;
            foreach(var id in x)
            {
                cdd.Add(_incomes.GetChecks.Where(a=>a.Id==int.Parse(id)).Select(a => new cc() { Amount = a.Amount, DueDate = a.DueDate.ToShortDateString(), Name = a.Name, files = a.Photo }).First());
            }
            string json = JsonConvert.SerializeObject(cdd);
            System.IO.File.WriteAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json", string.Empty);
            System.IO.File.WriteAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json", json);
            return new JsonResult("sucess");
        }

        public async Task<ActionResult> OnPostUploadAsync(IList<IFormFile> files)

        {

            if (files != null && files.Count > 0)

            {


                return this.Content(await Uplode(files[0], "Check"));

            }

            return this.Content("Fail");

        }

        public async Task<IActionResult> OnPostAddAsync(uplodechkeck uplodechkeck)
        {
          int id=  _incomes.AddCheck(new Check() {
                Amount = uplodechkeck.Amount,
                DueDate = DateTime.Parse(uplodechkeck.DueDate),
                Name=uplodechkeck.Name,
                Photo=await Uplode(uplodechkeck.files,"Check")
            });
            var x = new cc() { Id = id, Amount = uplodechkeck.Amount, DueDate = uplodechkeck.DueDate, Name = uplodechkeck.Name, files = _incomes[id].Photo };
            ModelState.Clear();
            return new JsonResult(x);
        }

        private async Task<string> Uplode(IFormFile file, string name)
        {


            return await _file.Upload_Image((FormFile)file, name);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            {
                var car = new Car()
                {
                    Id = 0,
                    CarId = bUYACAR.CarID,
                    Insurance = bUYACAR.Insurance.Value,
                    ModelId = bUYACAR.ModelId,
                    MoreDetails = bUYACAR.moreDetails,
                    Owener = bUYACAR.CarOwener,
                };
                var salePerson = new SalePerson()
                {

                    Adress = bUYACAR.SaleAdress,
                    Name = bUYACAR.SaleName,
                    Phone = bUYACAR.SalePhone,
                    Idnumber = bUYACAR.IDNumber,
                    IdPhoto = await Uplode(bUYACAR.IdPhoto, "ID")
                };
                var outcome = new Outcome()
                {
                    Price = bUYACAR.PriceOutcome
                };
                int OutcomeId = _outcome.AddOutcome(outcome).Result;


                var buy = new Buy()
                {
                    Date = DateTime.Today,
                    CarId = await _car.AddCar(car),
                    CustomerId = await _saleperson.AddSalePerson(salePerson),
                };
                var buyrecords = new BuyRecords()
                {

                    BuyId = _buy.AddBuy(buy).Result,
                    OutcomeId = OutcomeId,
                    PartnerId = 1


                };
                await _buyrecord.AddBuyRecords(buyrecords);
                List<cc> dd = JsonConvert.DeserializeObject<List<cc>>(System.IO.File.ReadAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json"));

                await _cash.AddCashAsync(new Cash()
                {
                    Amount = bUYACAR.CashAmount[0],
                    Arrested = true,
                    OutcomeId = OutcomeId,
                    IncomeId = null,
                    DateArrested = DateTime.Today

                });
                for (int i = 1; i < bUYACAR.CashAmount.Count-1; i++)

                {

                    await _cash.AddCashAsync(new Cash()
                    {
                        Amount = bUYACAR.CashAmount[i],
                        Arrested = false,
                        OutcomeId = OutcomeId,
                        IncomeId = null

                    });
                }
                for (int i = 0; i < dd.Count; i++)

                {
                    if (_check[dd[i].Id] == null) {
                        _check.AddCheck(new Check()
                        {
                            Amount = dd[i].Amount,
                            OutcomeId = OutcomeId,
                            Name = dd[i].Name,
                            DueDate = DateTime.Parse(dd[i].DueDate),
                            IncomeId = null,

                            Photo = dd[i].files

                        });
                    }
                    else
                    {
                        var m = _check[dd[i].Id];
                        m.OutcomeId = OutcomeId;
                        await _check.UpdateCheck(dd[i].Id, m);
                    }


                }


            }
            callproc cc = new callproc();
            cc.updateCapitalShare(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            cc = null;

            return RedirectToPage("/gallary");
        }

    }
    public class cc
    {
        public string files { get; set; }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
  
        public string DueDate { get; set; }
       
    }
    public class ass{
        public string Id { get; set; }
    }


}