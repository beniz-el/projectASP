using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projectASP.Data;
using projectASP.Models;

namespace projectASP.Pages.Profs
{
    public class DetailsModel : PageModel
    {
        private readonly projectASP.Data.ASPContext _context;

        public DetailsModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        public Professeur Professeur { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Professeur = await _context.Professeur.FirstOrDefaultAsync(m => m.CIN == id);

            if (Professeur == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
