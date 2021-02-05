using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using projectASP.Models;

namespace projectASP.Pages
{
    public class NoteModel : PageModel
    {
        public string CIN { get; set; }

        public IList<Etudiant> etudiant { get; set; }

        public IList<Note> note { get; set; }

        private readonly projectASP.Data.ASPContext _context;

        public NoteModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }


        public async Task OnGetAsync()
        {
            CIN = HttpContext.Session.GetString("CIN");
            Console.Out.WriteLine(CIN);
            var notes = from m in _context.Notes
                         select m;
            if (!string.IsNullOrEmpty(CIN))
            {
                notes = notes.Where(s => s.CIN.Contains(CIN));
            }

            note = await notes.ToListAsync();
        }
    }
}
