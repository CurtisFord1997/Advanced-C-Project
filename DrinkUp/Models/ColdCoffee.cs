using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkUp.Models
{
    public class ColdCoffee
    {
        [Key]
        public int ColdCoffeeID { get; set; }
        public String ColdCoffeeType { get; set; }

        public String ColdCoffeeName { get; set; }

        public Boolean Caffiene { get; set; }

    }
}
