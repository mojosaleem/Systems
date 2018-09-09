using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ManegmentSystems.Data;
using ManegmentSystems.Data.Models;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManegmentSystems.Pages
{
    public class inputmodel
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public string Description { get; set; }
        public int? RecordId { get; set; }
    }
    [BindProperties]

    public class mantainModel : PageModel
    {
        private readonly IBuyRecords buyRecords;
        private readonly ISellrecord sellrecord;
        private readonly IAfterBuyExpncess afterBuyExpncess;
        private readonly IAfterSellExpncess afterSellExpncess;
        private readonly IIncome income;
        private readonly IOutcome outcome;
        private readonly ICash cash;
        public List<inputmodel> output { get; set; }
        public inputmodel input { get; set; }

        public mantainModel(IBuyRecords buyRecords,IOutcome outcome,ICash cash,IIncome income, ISellrecord sellrecord, IAfterBuyExpncess afterBuyExpncess, IAfterSellExpncess afterSellExpncess)
        {
            this.buyRecords = buyRecords;
            this.sellrecord = sellrecord;
            this.afterBuyExpncess = afterBuyExpncess;
            this.afterSellExpncess = afterSellExpncess;
            this.income = income;
            this.cash = cash;
            this.outcome = outcome;
        }
        private int recordID;
        private int carID;
        public void OnGet(int? id, bool x)
        {
            if (ModelState.IsValid)
            {

                HttpContext.Session.SetString("state", x.ToString());
                HttpContext.Session.SetString("CarID", id.Value.ToString());

                if (x)
                {
                    if (sellrecord.GetSellRecords.Where(a => a.Sale.CarId == id.Value).FirstOrDefault().AfterSellExpncess != null)
                    {

                        recordID = sellrecord.GetSellRecords.Where(a => a.Sale.CarId == id.Value).FirstOrDefault().Id;
                        output = sellrecord[recordID].AfterSellExpncess.Select(a => new inputmodel() { Amount = a.Amount, Date = a.Date, Description = a.Description, RecordId = a.RecordId }).ToList();
                        HttpContext.Session.SetString("recordID", recordID.ToString());

                    }
                }
                else
                {
                    if (buyRecords.GetBuyRecords.Where(a => a.Buy.CarId == id.Value).FirstOrDefault().AfterBuyExpencess != null)
                    {

                        recordID = buyRecords.GetBuyRecords.Where(a => a.Buy.CarId == id.Value).FirstOrDefault().Id;
                        output = buyRecords[recordID].AfterBuyExpencess.Select(a => new inputmodel() { Amount = a.Amount, Date = a.Date, Description = a.Description, RecordId = a.RecordId }).ToList();
                        HttpContext.Session.SetString("recordID", recordID.ToString());

                    }
                }
            }
            else
            {
                RedirectToPage("/gallary");
            }
        }

        public IActionResult OnPost()
        {
            var x = HttpContext.Session.GetString("state");
            int.TryParse(HttpContext.Session.GetString("recordID"), out recordID);
            int.TryParse(HttpContext.Session.GetString("CarID"), out carID);

            
            if (x != string.Empty && recordID != 0&&carID!=0)
            {
               
                if (HttpContext.Session.GetString("state") == "True" && int.TryParse(HttpContext.Session.GetString("recordID"), out recordID))
                {
                    afterSellExpncess.AddAfterSellExpncess(new AfterSellExpncess() { Amount = input.Amount, Date = DateTime.Today, Description = input.Description, RecordId = recordID });
                   
                    output = afterSellExpncess.GetallSellExpncesses.Where(a => a.RecordId == recordID).Select(a => new inputmodel() { Amount = a.Amount, Date = a.Date, Description = a.Description, RecordId = a.RecordId }).ToList();

                    var IncodeID = sellrecord[recordID].IncomeId;
                    var incomeObj = income[IncodeID.Value];
                    incomeObj.Price -= input.Amount;
                    income.UpdateIncome(IncodeID.Value, incomeObj);

                    cash.AddCashAsync(new Cash() {Amount=input.Amount,Arrested=true,DateArrested=DateTime.Today,IncomeId=IncodeID });
                 
                    ModelState.Clear();

                    callproc cc = new callproc();
                    cc.updateCapitalShare(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    cc = null;

                    
                    
                    return Redirect("/mantain?id=" + sellrecord[recordID].Sale.CarId + "&x=" + HttpContext.Session.GetString("state"));
                }
                else
                {
                    
                    afterBuyExpncess.AddAfterBuyExpncessAsync(new AfterBuyExpencess() { Amount = input.Amount, Date = DateTime.Today, Description = input.Description, RecordId = recordID });
                    output = afterBuyExpncess.GetAfterBuyExpncesses.Where(a => a.RecordId == recordID).Select(a => new inputmodel() { Amount = a.Amount, Date = a.Date, Description = a.Description, RecordId = a.RecordId }).ToList();
                    var outcomeID = buyRecords[recordID].OutcomeId;
                    var oucomeObj = outcome[outcomeID];
                    oucomeObj.Price += input.Amount;
                    outcome.UpdateOutcome(outcomeID, oucomeObj);

                    cash.AddCashAsync(new Cash() { Amount = input.Amount, Arrested = true, DateArrested = DateTime.Today, OutcomeId = outcomeID });
                    
                    ModelState.Clear();
                    //this code to update capital share using proc
                    //callproc cc = new callproc();
                    //cc.updateCapitalShare(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    //cc = null;
                    return Redirect("/mantain?id=" + buyRecords[recordID].Buy.CarId + "&x=" + HttpContext.Session.GetString("state"));
                }
            }
            return Page();
        }
    }
}
