using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManegmentSystems.Data.Models;
using ManegmentSystems.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace ManegmentSystems.Pages.CHECK
{
    public class CreateModel : PageModel
    {
        private readonly ICheck check;
        private readonly Ifile _file;

        public CreateModel(ICheck check, Ifile file)
        {
            this.check = check;
            this._file = file;
        }

        public IActionResult OnGet()
        {

            return Page();
        }

        [BindProperty]
        public Check Check { get; set; }
        [BindProperty]
        public IFormFile photo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            this.Check.Photo =await Uplode(photo, "Check");
            check.AddCheck(Check);
            

            return RedirectToPage("./Index");
        }
        private async Task<string> Uplode(IFormFile file, string name)
        {


            return await _file.Upload_Image((FormFile)file, name);

        }
    }
}