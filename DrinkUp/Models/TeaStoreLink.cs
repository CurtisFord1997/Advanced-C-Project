using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkUp.Models
{
    public class TeaStoreLink
    {
        [Key]
        [Column(Order = 0)]
        public int TeaId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int TeaStoreId { get; set; }
    }
}
