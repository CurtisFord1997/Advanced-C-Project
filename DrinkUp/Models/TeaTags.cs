using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DrinkUp.Models
{
    public class TeaTags
    {
        [Key]
        public int TeaTagID { get; set; }
        public string Tag { get; set; }
    }
}
