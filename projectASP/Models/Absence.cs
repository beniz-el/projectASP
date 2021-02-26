using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projectASP.Models
{
    public class Absence
    {
        [Key]
        public string CNE { get; set; }
         public string CIN { get; set; }
        public string matiere { get; set; }
        public string date { get; set; }
        public string justification { get; set; }
    }
}

