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
    public class DeleteModel : PageModel
    {
        private readonly ManegmentSystems.Data.Models.CarMangerContext _context;

        public DeleteModel(ManegmentSystems.Data.Models.CarMangerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Check Check { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Check = await _context.Check
                .Include(c => c.Income)
                .Include(c => c.Outcome).FirstOrDefaultAsync(m => m.Id == id);

            if (Check == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Check = await _context.Check.FindAsync(id);

            if (Check != null)
            {
                _context.Check.Remove(Check);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
