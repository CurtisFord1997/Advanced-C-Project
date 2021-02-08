using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkUp.Models
{
    public class Tea
    {
        [Key]
        public int TeaID { get; set; }
        
        public string TeaName { get; set; }

        public string Discription { get; set; }

        public string TeaType { get; set; }

        public string TeaBrand { get; set; }

        public bool Organic { get; set; }

        public char Caffene { get; set; }

        //this refers to bagged or loose leaf... etc
        public string BrewType { get; set; }

        public int BrewTempC { get; set; }

        public decimal BrewTime { get; set; }

        public string Source { get; set; }

    }
}
