using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Pages.CHECK
{
    public class IndexModel : PageModel
    {
        private readonly ManegmentSystems.Data.Models.CarMangerContext _context;

        public IndexModel(ManegmentSystems.Data.Models.CarMangerContext context)
        {
            _context = context;
        }

        public IList<Check> Check { get;set; }

        public async Task OnGetAsync()
        {
            Check = await _context.Check
                .Include(c => c.Income)
                .Include(c => c.Outcome).ToListAsync();
        }
    }
}
