using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projectASP.Models
{
    public class Etudiant
    {
        [Key]
        public String CIN { get; set; }
        public String login { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String datenaissance { get; set; }
        public String email { get; set; }
        public String tel { get; set; }

        public String CNE { get; set; }
        public String filiere { get; set; }
        public String password { get; set; }
        public String image { get; set; }

      public Etudiant() { }

        public Etudiant(string CIN)
        {
            this.CIN = CIN;
        }
       
    }
}
