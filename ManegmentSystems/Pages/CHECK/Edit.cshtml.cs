using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Pages.CHECK
{
    public class EditModel : PageModel
    {
        private readonly ManegmentSystems.Data.Models.CarMangerContext _context;

        public EditModel(ManegmentSystems.Data.Models.CarMangerContext context)
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
           ViewData["IncomeId"] = new SelectList(_context.Income, "Id", "Id");
           ViewData["OutcomeId"] = new SelectList(_context.Outcome, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Check).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckExists(Check.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CheckExists(int id)
        {
            return _context.Check.Any(e => e.Id == id);
        }
    }
}
