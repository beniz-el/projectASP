using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projectASP.Models;

namespace projectASP.Pages
{
    public class ProjetsModel : PageModel
    {
        private readonly projectASP.Data.ASPContext _context;

        public ProjetsModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        public IList<Projet> Projet { get; set; }

        public async Task OnGetAsync()
        {
            string filiere = HttpContext.Session.GetString("filiere");

            var projets = from m in _context.Projets
                          select m;
            if (!string.IsNullOrEmpty(filiere))
            {
                projets = projets.Where(s => s.filiere.Contains(filiere));
            }

            Projet = await projets.ToListAsync();

        }
    }
}
