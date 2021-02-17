using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkUp.Models
{
    public class Coffee
    {
        [Key]
        public int CoffeeID { get; set; }

        public string CoffeeName { get; set; }

        public string Description { get; set; }

        public string CoffeeType { get; set; }


        public Boolean Caffiene { get; set; }

       

    }
}
