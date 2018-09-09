using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Models;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LinqKit;
using PagedList;
using ReflectionIT.Mvc.Paging;
using Pioneer.Pagination;
using EntityFrameworkPaginate;
using ManegmentSystems.Domain_object;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.pages.Pages
{
    [Authorize]
    public class GallaryModel : PageModel
    {
        private readonly IManufacture manufacutre;
        private readonly ICar car;
        private readonly IBuy buy;
        private readonly IBuyRecords buyRecords;
        private readonly IOutcome outcome;
        private readonly IPaginatedMetaService _paginatedMetaService;
        public GallaryModel(IManufacture manufacutre, ICar car, IBuy buy, IBuyRecords buyRecords, IOutcome outcome, IPaginatedMetaService paginatedMetaService)
        {
            this.manufacutre = manufacutre;
            this.car = car;
            this.buy = buy;
            this.buyRecords = buyRecords;
            this.outcome = outcome;
            _paginatedMetaService = paginatedMetaService;
        }

        public string sortName { get; set; }
        [BindProperty]
        public string search { get; set; }
        public int index { get; set; }
        public string YearFrom { get; set; }
        public string YearTo { get; set; }
        public decimal priceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public decimal Manufactures { get; set; }
        public decimal models { get; set; }
        public PaginatedList<Car> pages { get; set; }
        public IQueryable<Search> cars { set; get; }

        public PaginatedMetaModel Start { get; set; }
        private readonly ICar sold;
        public PaginatedMetaModel Full { get; set; }

        public PaginatedMetaModel End { get; set; }

        public PaginatedMetaModel Partial { get; set; }
        public Page<Search> page        { get; set; }
        public PaginatedMetaModel Zero { get; set; }
       
     

        public async Task OnGetAsync(int price_from, int price_to, int Manufacture, int model, int? pageIndex,string search)
        {
            index = pageIndex??1;

            var x = buyRecords.GetRecords(0, int.MaxValue);
            
            this.cars = x;
            var count = cars.Count();
            this.cars=this.cars.Skip((pageIndex ?? 1 - 1) * count).Take(count);
            this.Manufactures = Manufacture;
            this.models = model;
            this.priceFrom = price_from;
            this.PriceTo = price_to;


           
            if (price_from != 0)
            {

                 x =x.Where(a=>a.PriceOutcome>=priceFrom );

                this.cars = x.Skip((pageIndex ?? 1 - 1) * count).Take(count);
            }
            if (price_to != 0)
            {

                x = x.Where(a => a.PriceOutcome <= priceFrom);

                this.cars = x.Skip((pageIndex ?? 1 - 1) * count).Take(count);
            }
       

            if (price_to != 0 && price_from != 0)
            {

                x = x.Where(a => a.PriceOutcome >= priceFrom && a.PriceOutcome <= PriceTo);

                this.cars = x.Skip((pageIndex ?? 1 - 1) * count).Take(count);
            }
            if (!string.IsNullOrEmpty(search))
            {
                this.cars = cars.Where(y => y.SallerName == search || y.SallerID == search);
            }
            if (model != 0 && Manufacture != 0)
            {
                this.cars = cars.Where(a => a.modelID == model && a.ManufactureID == Manufacture);
            }

            page =this.cars.Paginate(pageIndex??1, count);
            
         
          

        }
      

      
       
    }
}