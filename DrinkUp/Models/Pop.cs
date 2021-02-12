using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkUp.Models
{
    public class Pop
    {
        public int PopId { get; set; }

        public string PopName { get; set; }

        public string FruitFlavor { get; set; }

        public string Diet { get; set; }

        public string PackageType { get; set; }

        public string PreferTemp { get; set; }

        public string Sugar { get; set; }

        public int NumDrinkPerDay { get; set; }
    }

}
