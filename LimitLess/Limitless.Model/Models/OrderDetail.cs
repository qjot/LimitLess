using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limitless.Model{
    [Table("Order Detail")]
    public class OrderDetail
    {
        public int orderDetailId { get; set; }
        public int orderId { get; set; }
        [Key]
        [ForeignKey("orderId")]
        public virtual Order order { get; set; }

        [Key]
        public int productId { get; set; }
        [Required]
        public string name{ get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public decimal unitPrice { get; set; }
        [Required]
        public short quantity { get; set; }
        [Required]
        public float discount { get; set;  }
        // TODO virtual opcja zakuu produku, kartwy, wstępu czy coś w tym stylu.k
    }
}
