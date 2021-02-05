using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using projectASP.Data;
using projectASP.Models;

namespace projectASP.Pages.Profs
{
    public class CreateModel : PageModel
    {
        private readonly projectASP.Data.ASPContext _context;

        public CreateModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Professeur Professeur { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Professeur.Add(Professeur);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
