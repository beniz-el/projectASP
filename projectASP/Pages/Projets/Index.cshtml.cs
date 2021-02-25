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
    public class IndexModel : PageModel
    {
        private readonly projectASP.Data.ASPContext _context;

        public IndexModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        public IList<Projet> Projet { get;set; }

        public async Task OnGetAsync()
        {
            Projet = await _context.Projets.ToListAsync();
        }
    }
}
