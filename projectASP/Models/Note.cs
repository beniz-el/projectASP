using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projectASP.Models
{
    public class Note
    {
        [Key]
        public string CIN { get; set; }
        public string matiere { get; set; }
        public string note { get; set; }
        public string filiere { get; set; }


        public Note(string CIN)
        {
            this.CIN = CIN;
        }
    }
}
