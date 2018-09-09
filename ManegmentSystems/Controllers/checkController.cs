using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Models;
using ManegmentSystems.Pages;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class checkController : ControllerBase
    {
        private readonly ICheck Check;
        private readonly Ifile _file;

        public checkController(ICheck check, Ifile file)
        {
            Check = check;
            _file = file;

        }

        [HttpPost(Name = "add")]
        [Route("[action]")]
        public async Task<IActionResult> addAsync([FromBody]uplodechkeck cc)
        {

            //List<cc> cdd = check.Select(a => new cc() { Amount = a.Amount, DueDate = a.DueDate, Name = a.Name,files=a.files }).ToList();
            //string json = JsonConvert.SerializeObject(cdd);
            //System.IO.File.WriteAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json", string.Empty);
            //System.IO.File.WriteAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json", json);
            return this.Content("Sucess");

        }



        //// POST: api/check
        //[HttpPost]
        //public IActionResult Post([FromBody]uplodechkeck cc)
        //{
            
           
        //    var checks = Check.GetChecks.Where(a => a.OutcomeId == null).Select(a => new cc()
        //    {
        //        Id = a.Id,
        //        Amount = a.Amount,
        //        DueDate = a.DueDate.ToShortDateString(),
        //        Name = a.Name
        //    }).AsQueryable();

        //    string json = JsonConvert.SerializeObject(checks);
        //    System.IO.File.WriteAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json", string.Empty);
        //    System.IO.File.WriteAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json", json);



        //    //System.IO.File.WriteAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json", json);
        //    //List<cc> ck = JsonConvert.DeserializeObject<List<cc>>(System.IO.File.ReadAllText("C:\\Users\\wwwmu\\source\\repos\\ManegmentSystems\\ManegmentSystems\\wwwroot\\data.json"));

        //    return this.Content(id+"");
        //}

        // PUT: api/check/5

        private async Task<string> Uplode(IFormFile file, string name)
        {


            return await _file.Upload_Image((FormFile)file, name);

        }

    }
    public class uplodechkeck
    {

        public decimal Amount { get; set; }
        public string DueDate { get; set; }
        public string Name { get; set; }
        public IFormFile files { get; set; }
    }
}
