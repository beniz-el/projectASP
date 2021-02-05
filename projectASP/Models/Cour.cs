using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projectASP.Models
{
    public class Cour
    {
        [Key]
        public string nom { get; set; }
         public string CIN { get; set; }
         public string semestre { get; set; }
        public string date { get; set; }
        public string filiere { get; set; }
        public string lien { get; set; }
    }
}
