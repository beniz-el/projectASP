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
    public class EditProfileModel : PageModel
    {
        [BindProperty]
        public Etudiant Etudiant { get; set; }
        public string CIN { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string datenaissance { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string CNE { get; set; }
        public string filiere { get; set; }
        public string image { get; set; }


        private readonly projectASP.Data.ASPContext _context;

        public EditProfileModel(projectASP.Data.ASPContext context)
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
            CNE = HttpContext.Session.GetString("CNE");
            filiere = HttpContext.Session.GetString("filiere");
            image = HttpContext.Session.GetString("image");
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(Etudiant.CIN))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Profile");
        }

        private bool EtudiantExists(string id)
        {

            return _context.Etudiants.Any(e => e.CIN == id);
        }


    }
}
