﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projectASP.Data;
using projectASP.Models;

namespace projectASP.Pages.Cours
{
    public class DeleteModel : PageModel
    {
        private readonly projectASP.Data.ASPContext _context;

        public DeleteModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cour Cour { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cour = await _context.Cours.FirstOrDefaultAsync(m => m.nom == id);

            if (Cour == null)
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

            Cour = await _context.Cours.FindAsync(id);

            if (Cour != null)
            {
                _context.Cours.Remove(Cour);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
