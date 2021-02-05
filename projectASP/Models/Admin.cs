using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projectASP.Models
{
    public class Admin
    {
        [Key]
        public String login { get; set; }
        public String password { get; set; }
    }
}
