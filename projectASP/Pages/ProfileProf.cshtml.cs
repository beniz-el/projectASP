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
    public class ProfileProfModel : PageModel
    {
        private readonly projectASP.Data.ASPContext _context;

        public ProfileProfModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        public IList<Professeur> Professeur { get; set; }

        public async Task OnGetAsync()
        {
            string CIN = HttpContext.Session.GetString("CIN");
            //Console.Out.WriteLine(CIN);
            var professeurs = from m in _context.Professeurs
                            select m;
            if (!string.IsNullOrEmpty(CIN))
            {
                professeurs = professeurs.Where(s => s.CIN.Contains(CIN));
            }

            Professeur = await professeurs.ToListAsync();
            HttpContext.Session.SetString("CIN", CIN);
        }
    }
}
