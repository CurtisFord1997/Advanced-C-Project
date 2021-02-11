using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkUp.Models
{
    public class Frapuccino
    {
        [Key]
        public int FrapID { get; set; }
        public String FrapType { get; set; }
        public String FrapName { get; set; }
    }
}
