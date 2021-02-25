using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projectASP.Data;
using projectASP.Models;

namespace projectASP.Pages.Projets
{
    public class DeleteModel : PageModel
    {
        private readonly projectASP.Data.ASPContext _context;

        public DeleteModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Projet Projet { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Projet = await _context.Projets.FirstOrDefaultAsync(m => m.nom == id);

            if (Projet == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Projet = await _context.Projets.FindAsync(id);

            if (Projet != null)
            {
                _context.Projets.Remove(Projet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
