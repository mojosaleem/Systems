using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Domain_object;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManegmentSystems.Pages
{
    public class infoModel : PageModel
    {
        private readonly IcarInfo icarInfo;
        
        public BUYACARINFO bUYACARINFO { get; set; }
        public infoModel(IcarInfo icarInfo)
        {
            this.icarInfo = icarInfo;
        }

        public void OnGet(int carid)
        {

            bUYACARINFO = icarInfo[carid];
         
        }
    }
}