using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace projectASP.Pages
{
    public class CoursModel : PageModel
    {
        private readonly projectASP.Data.ASPContext _context;

        public CoursModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        public IList<Cour> Cour { get; set; }

        public async Task OnGetAsync()
        {
            string filiere = HttpContext.Session.GetString("filiere");

            var cours = from m in _context.Cours
                            select m;
            if (!string.IsNullOrEmpty(filiere))
            {
                cours = cours.Where(s => s.filiere.Contains(filiere));
            }

            Cour = await cours.ToListAsync();

        }

}
}
