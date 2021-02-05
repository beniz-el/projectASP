using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace projectASP.Pages
{
    public class ProfileModel : PageModel
    {
        
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
    }
}
