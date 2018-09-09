using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufactureController : ControllerBase
    {
        public readonly IManufacture _manufacture;
        public ManufactureController(IManufacture manufacture)
        {
            _manufacture = manufacture;
           
        }
        //api/Manufacture
        [HttpGet]
        public IQueryable<Manufacture> GetManufactures()
        {
            return _manufacture.GetManufactures;
        }
    }
}