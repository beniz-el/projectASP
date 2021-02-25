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
    public class EditProfilProfModel : PageModel
    {
        [BindProperty]
        public Professeur professeur { get; set; }
        public string CIN { get; set; }
        public string login { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string datenaissance { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string image { get; set; }
        public string matierespecialise { get; set; }
        public string password { get; set; }


        private readonly projectASP.Data.ASPContext _context;

        public EditProfilProfModel(projectASP.Data.ASPContext context)
        {
            _context = context;
        }



        public void OnGet()
        {
            CIN = HttpContext.Session.GetString("CIN");
            login = HttpContext.Session.GetString("login");
            password = HttpContext.Session.GetString("password");
            nom = HttpContext.Session.GetString("nom");
            prenom = HttpContext.Session.GetString("prenom");
            datenaissance = HttpContext.Session.GetString("datenaissance");
            email = HttpContext.Session.GetString("email");
            tel = HttpContext.Session.GetString("tel");
            image = HttpContext.Session.GetString("image");
            matierespecialise = HttpContext.Session.GetString("matierespecialise");

        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(professeur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesseurExists(professeur.CIN))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ProfileProf");
        }

        private bool ProfesseurExists(string id)
        {

            return _context.Etudiants.Any(e => e.CIN == id);
        }


    }
}
