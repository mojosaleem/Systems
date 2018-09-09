using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ManegmentSystems.Data;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManegmentSystems.Pages
{
    public class outputModel
    {
        public int numberOfSoldCar { get;  set; }
        public int numberOfbuyCar { get;  set; }
        public int capitalshare { get;  set; }
        public int NumberOfCheck { get;  set; }
        public int AmountOfCheck { get;  set; }
        public int amountOfCash { get;  set; }

    }

    public class IndexModel : PageModel
    {
        private readonly ICar car;
        private readonly ICapitalShare capitalShare;
        private readonly ICheck check;
        private readonly IAfterSellExpncess afterSellExpncess;

        private readonly ICash cash;

        public outputModel model { get; set; }
        public IndexModel(ICar car, ICapitalShare capitalShare, IAfterSellExpncess afterSellExpncess,ICheck check, ICash cash)
        {
            this.car = car;
            this.afterSellExpncess = afterSellExpncess;
            this.capitalShare = capitalShare;
            this.check = check;
            this.cash = cash;
            model = new outputModel();
        }

        public void OnGet()
        {
            callproc cc = new callproc();
            cc.updateCapitalShare(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            cc = null;

            model.amountOfCash =(int) cash.GetCashes.Where(a=>a.OutcomeId==null).Sum(a=>a.Amount) - (int) afterSellExpncess.GetallSellExpncesses.Sum(a=>a.Amount);
            model.AmountOfCheck = (int)check.GetChecks.Where(a => a.OutcomeId == null ).Sum(a => a.Amount);
            model.capitalshare =(int) capitalShare.GetCapitalShares.Where(a => a.Amount >= a.Amount).FirstOrDefault().Amount;
            model.numberOfbuyCar = car.GetCars.Count();
            
            model.numberOfSoldCar = car.GetCars.ToList().Where(a => a.Sold == true).Count();
            model.NumberOfCheck =check.GetChecks.Where(a => a.OutcomeId == null || a.OutcomeId == 0).Count();
        }
    }
}