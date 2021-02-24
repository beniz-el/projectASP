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
    public class ProfileModel : PageModel
    {
       

            private readonly projectASP.Data.ASPContext _context;

        public ProfileModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get; set; }

        public async Task OnGetAsync()
        {
            string CIN = HttpContext.Session.GetString("CIN");
            //Console.Out.WriteLine(CIN);
            var etudiants = from m in _context.Etudiants
                           select m;
            if (!string.IsNullOrEmpty(CIN))
            {
                etudiants = etudiants.Where(s => s.CIN.Contains(CIN));
            }

           Etudiant = await etudiants.ToListAsync();
           HttpContext.Session.SetString("CIN", CIN);
        }


    }
}
