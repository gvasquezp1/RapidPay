using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPlay.Models
{
    [Table("credit_cards")]
    public class CreditCard
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string number { get; set; }
        public DateTime expiration_date { get; set; }
        public bool locked { get; set; }
    }
}
