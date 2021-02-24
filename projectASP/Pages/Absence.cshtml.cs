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
    public class AbsenceModel : PageModel
    {
        private readonly projectASP.Data.ASPContext _context;

        public AbsenceModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }

        public IList<Absence> Absence { get; set; }

        public async Task OnGetAsync()
        {
            string CNE = HttpContext.Session.GetString("CNE");

            var absences = from m in _context.Absences
                        select m;
            if (!string.IsNullOrEmpty(CNE))
            {
                absences = absences.Where(s => s.CNE.Contains(CNE));
            }

            Absence = await absences.ToListAsync();

        }

    }
}
