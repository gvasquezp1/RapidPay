using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPlay.Models
{
    [Table("fees")]
    public class Fees
    {
        public int id { get; set; }
        public decimal fee { get; set; }
        public DateTime FeeDate { get; set; }
    }
}
