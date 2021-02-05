using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectASP.Models;

namespace projectASP.Pages
{
    public class loginModel : PageModel
    {

        public Etudiant Etudiant { get; set; }
        public void OnGet()
        {
        }
    }
}
