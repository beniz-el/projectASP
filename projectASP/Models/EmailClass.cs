using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projectASP.Models
{
    public class EmailClass
    {
        [Key]
        public string subject { get; set; }

        public string mail { get; set; }

        public string CIN { get; set; }

    }
}
