using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Model
{
    [Table("Membership")]
    public class Membership
    {
        [Key]
        public int membershipId { get; set;}
        public string title { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }

    }
}
