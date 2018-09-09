using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManegmentSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICash Cash;

        public ValuesController(ICash car)
        {
            this.Cash = car;
        }

        // PUT: /User/Edit
        [HttpPut("Edit/{id:int}")]
        public async Task<JsonResult> EditAsync(int id, User user)
        {
            if(Cash[id]==null)
            return new JsonResult("Does not exist");
            else
            {
                var x =Cash[id];
                x.Arrested = user.arrested;
               if( await Cash.UpdateCash(id, x))
                {
                    return new JsonResult("Done");
                }
                else
                {
                    return new JsonResult("Error");
                }
            }
        }
      
    }
    public class User
    {
        public int    id { get; set; }
        public bool    arrested { get; set; }
    }
  
}