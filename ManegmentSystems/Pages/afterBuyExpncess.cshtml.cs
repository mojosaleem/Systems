using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManegmentSystems.Pages
{
    public class expencessVM
    {
        public int Amount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string description  { get; set; }
    }
    public class afterBuyExpncessModel : PageModel
    {
        private readonly IAfterBuyExpncess iafterBuyExpncess;
        private readonly IAfterSellExpncess afterSellExpncess;
        private readonly IBuyRecords buyRecords;
        private readonly ISellrecord sellrecord;

        [BindProperty]
        public expencessVM Input { get; set; }
        public List<AfterBuyExpencess> buyexpencesses { get; set; }
        public List<AfterSellExpncess> sellexpencesses { get; set; }
        public afterBuyExpncessModel(IAfterBuyExpncess iafterBuyExpncess, IAfterSellExpncess afterSellExpncess, IBuyRecords buyRecords, ISellrecord sellrecord)
        {
            this.iafterBuyExpncess = iafterBuyExpncess;
            this.afterSellExpncess = afterSellExpncess;
            this.buyRecords = buyRecords;
            this.sellrecord = sellrecord;
        }

        public void OnGet(int id,bool x)
        {
            if (x)
            {
              
            }

        }
    }
}