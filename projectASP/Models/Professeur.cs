using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projectASP.Models
{
    public class Professeur
    {
        [Key]
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
    }
}
