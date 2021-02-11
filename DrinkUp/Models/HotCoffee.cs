using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkUp.Models
{
    public class HotCoffee
    {
        [Key]
        public int HotCoffeeID { get; set; }
        public String HotCoffeeType { get; set; }
        public String HotCoffeeName { get; set; }
    }
}
