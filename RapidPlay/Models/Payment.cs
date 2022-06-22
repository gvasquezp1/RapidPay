using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPlay.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int creditCardId { get; set; }
        public int clientid { get; set; }
        public DateTime docdate { get; set; }
        public DateTime docduedate { get; set; }
        public decimal fee { get; set; }
        public decimal DocTotal { get; set; }
        public bool locked { get; set; }
    }
}
