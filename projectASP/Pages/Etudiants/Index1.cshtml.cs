using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.EntityFrameworkCore;
using projectASP.Data;
using projectASP.Models;

namespace projectASP.Pages.Etudiants
{
    public class Index1Model : PageModel
    {
        private readonly projectASP.Data.ASPContext _context;
        public Index1Model(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get; set; }

        public async Task OnGetAsync()
        {
            Etudiant = await _context.Etudiants.ToListAsync();
        }
      
    }
}
